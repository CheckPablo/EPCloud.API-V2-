using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Data.Migrations;
using ExamPortalApp.Infrastructure.Constants;
using ExamPortalApp.Infrastructure.Exceptions;
using ExamPortalApp.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IBackgroundQueue<Dictionary<int, int[]>> _resendQueue;
        private readonly IBackgroundQueue<Tuple<int, int[]>> _createQueue;
        private readonly ExamPortalSettings _examPortalSettings;
        private readonly IEmailService _emailService;
        private readonly IRepository _repository;
        private readonly IGradeRepository _gradeRepository;
        private readonly DecodedUser? _user;
        private IEnumerable<StudentSubject> linkResult;

        public StudentRepository(IRepository repository,IGradeRepository gradeRepository,  IHttpContextAccessor accessor, IBackgroundQueue<Dictionary<int, int[]>> resendQueue,
            IBackgroundQueue<Tuple<int, int[]>> createQueue, IEmailService emailService, IOptions<ExamPortalSettings> options)
        {
            _repository = repository;
            _gradeRepository = gradeRepository; 
            _user = accessor.GetLoggedInUser();
            _resendQueue = resendQueue;
            _createQueue = createQueue;
            _emailService = emailService;
            _examPortalSettings = options.Value;
        }

        public async Task<Student> AddAsync(Student entity)
        {
            if (_user is null) throw new Exception(ErrorMessages.Auth.Unauthorised);

            var center = await _repository.GetByIdAsync<Center>(_user.CenterId, x => x.Students);

            if (center is null) throw new Exception(ErrorMessages.Auth.Unauthorised);
            if (center.MaximumLicense <= center.Students.Count()) throw new InvalidOperationException("Maximum number of students reached.");
            var studentExists = await _repository.AnyAsync<Student>(x => x.StudentNo == entity.StudentNo );
            if (studentExists)
            {
                throw new Exception(ErrorMessages.StudentEntryChecks.StudentExists);
            }
            var password = GeneralHelpers.RandomPassword(8);

            entity.CenterId = center.Id;
            entity.ModifiedBy = _user.Id;
            entity.ExamNo = password;
            entity.EncrytedPassword= PasswordHelper.Encrypt(password, _examPortalSettings.EncryptionKey);
         
            var student = await _repository.AddAsync(entity, true);
            var examNo = CreateExamNumber(center.Prefix, student.Id);

            student.ExamNo = examNo;
            entity.ExamNo = examNo;
            SendRegistrationEmail(entity, password);
            await _repository.UpdateAsync(student, true);

            return student;
        }

        public string CreateExamNumber(string? prefix, int studentId)
        {
            var random = new Random();
            string randomPart = (random.NextDouble().ToString("F11").Substring(2, 2) + random.NextDouble().ToString("F11").Substring(3, 10)).Substring(0, 2);
            string uniqueExamNo = $"{prefix}{randomPart}{(studentId.ToString("D9"))}";

            return uniqueExamNo;
        }

        public bool CreateLoginCredentials(int[] studentIds)
        {
            if (_user is null) throw new Exception(ErrorMessages.Auth.Unauthorised);

            Tuple<int, int[]> data = Tuple.Create(_user.Id, studentIds); ;

            _createQueue.Enqueue(data);

            return true;
        }

        public async Task CreateLoginCredentialsAsync(Tuple<int, int[]> data)
        {
            var (userId, studentIds) = data;
            var user = await _repository.GetByIdAsync<User>(userId);

            if (user is null) return;

            var center = await _repository.GetByIdAsync<Center>(user.CenterId);

            if (center is null) return;

            await ProcessStudentIdsAsync(userId, studentIds, center);
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _repository.DeleteAsync<Student>(id);

            return await _repository.CompleteAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            //var students = await _repository.GetAllAsync<Student>();

            //foreach (var student in students)
            //{
            //    if (student.EncrytedPassword is null)
            //    {
            //        var password = PasswordHelper.GeneratePassword();

            //        student.EncrytedPassword = PasswordHelper.Encrypt(password, _examPortalSettings.EncryptionKey);

            //        await _repository.UpdateAsync(student);
            //    }
            //}

            //await _repository.CompleteAsync();

            //return students;
            //return await _repository.GetAllAsync<Student>();
            if (_user == null)
            {
                throw new Exception(ErrorMessages.Auth.Unauthorised);
            }
            var students = await _repository.GetWhereAsync<Student>(x => x.CenterId == _user.CenterId);
            //return students.OrderBy(x => x.Id);
            return students.OrderBy(x => x.Id);
        }

        public async Task<Student> GetAsync(int id)
        {
            var student = await _repository.GetByIdAsync<Student>(id, x => x.StudentSubjects);

            if (student is null) throw new EntityNotFoundException<Student>(id);

            return student;
        }

        public async Task<IEnumerable<InvigilatorStudentLinkResult>> GetInvigilatorStudentLinksAsync(int userId, int? gradeId = null, int? subjectId = null)
        {
            if (_user is null) throw new Exception(ErrorMessages.Auth.Unauthorised);

            var students = await _repository.GetWhereAsync<Student>(x => x.CenterId == _user.CenterId,
                x => x.StudentSubjects, x => x.InvigilatorStudentLinks);

            if (gradeId is not null) students = students.Where(x => x.GradeId == gradeId).ToList();
            if (subjectId is not null) students = students.Where(x => x.StudentSubjects.Any(y => y.SubjectId == subjectId)).ToList();

            var result = students.Select(x => new InvigilatorStudentLinkResult
            {
                ExamNo = x.ExamNo,
                IdNumber = x.IdNumber,
                Linked = x.InvigilatorStudentLinks.Any(x => x.InvigilatorId == userId),
                StudentId = x.Id,
                Name = x.Name,
                Surname = x.Surname,
            });
            
            return result.OrderBy(x => x.Name).ThenBy(x => x.Surname);
        }
        
        private IEnumerable<Student> GetOrdered(IEnumerable<Student> students) => students.OrderBy(x => x.Name).ThenBy(x => x.Surname);

       /* public async Task LinkStudentToSubjectsAsync(int studentId, int[] subjectIds)
        {
            var currenctLinks = await _repository.GetWhereAsync<StudentSubject>(x => x.StudentId == studentId);

            foreach (var subjectId in subjectIds)
            {
                var studentSubject = currenctLinks.FirstOrDefault(x => x.SubjectId == subjectId && x.StudentId == studentId);

                if (studentSubject != null)
                {
                    currenctLinks = currenctLinks.Where(x => x.Id != studentSubject.Id);
                }
                else
                {
                    studentSubject = new StudentSubject
                    {
                        SubjectId = subjectId,
                        StudentId = studentId,
                    };

                    await _repository.AddAsync(studentSubject);
                    await _repository.CompleteAsync();
                }
            }

            foreach (var studentSubject in currenctLinks)
            {
                await _repository.DeleteAsync<StudentSubject>(studentSubject.Id);
            }

            await _repository.CompleteAsync();
        }*/

        public async Task<bool> LinkStudentToSubjectsAsync(int studentId, int[] subjectIds)
        {
            DeleteSubjectStudentLinks(studentId);
            var parameters = new Dictionary<string, object>();
            foreach (var subjectId in subjectIds)
            {
                parameters.Clear();
                parameters.Add(StoredProcedures.Params.StudentId, studentId);
                parameters.Add(StoredProcedures.Params.SubjectId, subjectId);
               
                linkResult = await _repository.ExecuteStoredProcAsync<StudentSubject>(StoredProcedures.LinkStudentSubjects, parameters);
            }
            if (linkResult is not null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DelinkStudentToSubjectsAsync(int studentId, int[] subjectIds)
        {
            //DeleteSubjectStudentLinks(studentId);
            var parameters = new Dictionary<string, object>();
            foreach (var subjectId in subjectIds)
            {
                parameters.Clear();
                parameters.Add(StoredProcedures.Params.StudentId, studentId);
                //parameters.Add(StoredProcedures.Params.SubjectId, subjectId);

                linkResult = await _repository.ExecuteStoredProcAsync<StudentSubject>(StoredProcedures.DeleteStudentSubjects, parameters);
            }
            if (linkResult is not null)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> DeleteSubjectStudentLinks(int studentId)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(StoredProcedures.Params.StudentId, studentId);
            var result = _repository.ExecuteStoredProcedureAsync<StudentSubject>(StoredProcedures.DeleteStudentSubjects, parameters);
           
            if (linkResult is not null)
            {
                return true;
            }
            return false;
        }

        private async Task ProcessStudentIdsAsync(int userId, int[] studentIds, Center? center = null, bool createNewPassword = true)
    {
        var user = await _repository.GetByIdAsync<User>(userId);
        var stringBuilder = new StringBuilder();

        if (user is null) return;

        foreach (var studentId in studentIds)
        {
            var student = await _repository.GetByIdAsync<Student>(studentId);
            var password = string.Empty;
            //var password = student.EncrytedPassword; 

            if (student is null) continue;

            //if (createNewPassword)
            //{
               // password = GeneralHelpers.RandomPassword(8);

               // student.EncrytedPassword = PasswordHelper.Encrypt(password, _examPortalSettings.EncryptionKey);
           // }
           // else
            //{
                if (student.EncrytedPassword is not null)
                {
                    password = PasswordHelper.Decrypt(student.EncrytedPassword, _examPortalSettings.EncryptionKey);
                }
            //}

            if (center is not null)
            {
                student.ExamNo = CreateExamNumber(center.Prefix, studentId);
            }

            await _repository.UpdateAsync(student);

            SendLoginCredentials(student, password);

            stringBuilder.Append("<tr>");
            stringBuilder.Append($"<td>{student.Name} {student.Surname}</td>");
            stringBuilder.Append($"<td>{student.EmailAddress}</td>");
            stringBuilder.Append($"<td>{student.ExamNo}</td>");
            stringBuilder.Append($"<td>{password}</td>");
            stringBuilder.Append("</tr>");
        }

        SendLoginCredentialsConfirmation(user, stringBuilder.ToString());
    }

    public async Task<IEnumerable<Student>> SearchAsync(StudentSearcher? searcher)
    {
        if (_user is null) throw new Exception(ErrorMessages.Auth.Unauthorised);

        var query = _repository.GetQueryable<Student>()
            .Include(s => s.Grade)
            .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
            .Where(x => x.CenterId == _user.CenterId);

        if (searcher?.GradeId is not null) query = query.Where(x => x.GradeId == searcher.GradeId);
        if (searcher?.SubjectId is not null) query = query.Where(s => s.StudentSubjects.Any(ss => ss.SubjectId == searcher.SubjectId));
        if (!string.IsNullOrWhiteSpace(searcher?.Name)) query = query.Where(s => s.Name != null && s.Name.Contains(searcher.Name.ToLower().Trim()));

            var data = await query.ToListAsync();

            var result = data.Select(x => new Student
            {
                Id = x.Id,
                ExamNo = x.ExamNo,
                IdNumber = x.IdNumber,
                EmailAddress = x.EmailAddress,
                Name = x.Name,
                Surname = x.Surname,
                Grade = new Grade
                {
                    Id = x.Grade.Id,
                    Code = x.Grade?.Code,
                },
                PlainPassword = PasswordHelper.Decrypt(x.EncrytedPassword, _examPortalSettings.EncryptionKey),
                SentConfirmation = !String.IsNullOrEmpty(x.EncrytedPassword),

                //SentConfirmation = (x.SentConfirmation.HasValue) ? x.SentConfirmation.Value : (!String.IsNullOrEmpty(x.ExamNo) | !String.IsNullOrEmpty(x.PlainPassword) | (x.PlainPassword.Length < 1)) ? true : false,
                //SentConfirmation = // if (String.IsNullOrEmpty(PlainPassword))
                // if (String.IsNullOrEmpty(PlainPassword))
            }); ;
            Console.WriteLine(result);
            return GetOrdered(result);
        }

        
        public bool SendLoginCredentials(int[] studentIds)
        {
            if (_user is null) throw new Exception(ErrorMessages.Auth.Unauthorised);

            var data = new Dictionary<int, int[]>
            {
                { _user.Id, studentIds }
            };

            _resendQueue.Enqueue(data);

            return true;
        }

        private void SendLoginCredentials(Student student, string password)
        {
            if (student.EmailAddress is null) return;

            //var body = $"Hi {student.Name} 🙋🏽‍, \n\nWe are sending you your Exam Portal Cloud credentails below \n\n"
            //    + " Username: " + student.ExamNo + "\n"
            //    + " Password: " + password + "\n\n"
            //    + " Use the following link to login : www.examportalcloud.co.za ";

            //var email = new EmailDto
            //{
            //    EmailAddesses = new List<string> { student.EmailAddress },
            //    MessageBody = body,
            //    Subject = "Exam Portal Cloud Credentials"
            //};
          
            //_emailService.SendOrQueue(email, true);
            MailMessage mail = new MailMessage();
            //var mailAd = users.Last(x => x.UserEmailAddress.Length > 0);
            mail.From = new MailAddress("qiscmapp@gmail.com");
            //mail.From = new MailAddress("qiscmapp@gmail.com");

            mail.To.Add("Tinashe@v-soft.co.za");
            mail.To.Add(student.EmailAddress);
            //mail.Bcc.Add("support@v-soft.co.za");
            mail.Bcc.Add("syntaxdon@gmail.com");
            mail.Subject = " Login Details for Exam Portal Cloud";

            mail.Body = " Dear" +"".PadRight(1)+ student.Name +""+" ,\n\n"
            + " Your credentials have been sent. \n \n"
            + " Your New login details: \n \n"
            + " Exam Number: " + student.ExamNo + "\n"
            + " Password: " + password + "\n \n"
            + " Use the following link to login : https://examportalcloud.co.za/ . \n \n "
            + " IMPORTANT: Please ensure you have Safe Exam Browser installed your on your Windows / Mac computer/laptop. You may download it from here: https://sourceforge.net/projects/seb/files/seb/SEB_2.4.1/SafeExamBrowserInstaller.exe/download \n \n"

            + " If you experience any problems during login or during your examination, please contact your exam invigilator immediately. \n \n"
            + " Kind Regards, \n"
            + " The Exam Portal Cloud team";
            SmtpClient smtpServer = new SmtpClient();
            //smtpServer.UseDefaultCredentials = false;;
            smtpServer.Host = "smtp.gmail.com";
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.Credentials = new NetworkCredential("qiscmapp@gmail.com", "gkrikvoauqlshyzg");
            //smtpServer.Credentials = new NetworkCredential("qiscmapp@gmail.com", "insyduliawxhesgf");

            smtpServer.Timeout = 20000;
            smtpServer.Send(mail);
        }

        public async Task SendLoginCredentialsAsync(Dictionary<int, int[]> data)
        {
            foreach (var item in data)
            {
                await ProcessStudentIdsAsync(item.Key, item.Value);
            }
        }

        private void SendLoginCredentialsConfirmation(User user, string rows)
        {
            //if (user.UserEmailAddress is null) return;

            //var body = $"Hi {user.Name} 🙋🏽‍, \n\nWe have sent the following credentials on your behalf: \n\n"
            //    + "<table class='width:100%'>"
            //    + "<th><td>Name</td><td>Email</td><td>Exam No.</td><td>New Password</td></th>"
            //    + $"<tbody>{rows}</tbody>"
            //    + "</table>";

            //var email = new EmailDto
            //{
            //    EmailAddesses = new List<string> { user.UserEmailAddress },
            //    MessageBody = body,
            //    Subject = "Exam Portal Cloud Credentials"
            //};

            //_emailService.SendOrQueue(email, true);
        }

        private void SendRegistrationEmail(Student student, string password)
        {
            //if (student.EmailAddress is null) return;

            //var body = "Dear User: \n \n"
            //    + " Welcome to Exam Portal Cloud \n \n"
            //    + " Your Login Registration details: \n \n"
            //    + " Exam Number: " + student.ExamNo + "\n"
            //    + " Password: " + password + "\n \n"
            //    + " Use the following link to login : https://examportalcloud.co.za/ and select Student Login. \n \n "
            //    + " IMPORTANT: Please ensure you have Safe Exam Browser installed on your Windows / Mac computer/laptop. You may download it from here: https://sourceforge.net/projects/seb/files/seb/SEB_2.4.1/SafeExamBrowserInstaller.exe/download  If you do not have a Windows or a Mac book computer / laptop, you do not need to install Safe Exam Browser. \n \n"
            //    + " If you experience any problems during login or during your examination, please contact your exam invigilator immediately. \n \n"
            //    + " Kind Regards, \n"
            //    + " The Exam Portal Cloud team";

            //var emailDto = new EmailDto
            //{
            //    EmailAddesses = new List<string> { student.EmailAddress },
            //    MessageBody = body,
            //    Subject = "Login Details for Exam Portal Cloud",

            //};

            //_emailService.SendOrQueue(emailDto);
            MailMessage mail = new MailMessage();
            //sending when emailing a studenton add student
            mail.From = new MailAddress("qiscmapp@gmail.com");
            mail.To.Add("Tinashe@v-soft.co.za");
            mail.To.Add(student.EmailAddress); 
            //mail.Bcc.Add("support@v-soft.co.za");
            mail.Bcc.Add("syntaxdon@gmail.com");
            mail.Subject = " Login Details for Exam Portal Cloud";
 
            mail.Body = " Dear" + "".PadRight(1) + student.Name + "" + " ,\n\n"
            + " Thank you for registering your account on Exam Portal Cloud.\n \n"
            + " Your Login Registration details: \n \n"
            + " ExamNo: " + student.ExamNo + "\n"
            + " Password: " + password + "\n \n"
            + " Use the following link to login : https://examportalcloud.co.za/ and select Student Login. \n \n "
            + " IMPORTANT: Please ensure you have Safe Exam Browser installed on your Windows / Mac computer/laptop. You may download it from here: https://sourceforge.net/projects/seb/files/seb/SEB_2.4.1/SafeExamBrowserInstaller.exe/download  If you do not have a Windows or a Mac book computer / laptop, you do not need to install Safe Exam Browser. \n \n"
            + " If you experience any problems during login or during your examination, please contact your exam invigilator immediately. \n \n"
            + " Kind Regards \n"
            + " The Exam Portal Cloud team";

            SmtpClient smtpServer = new SmtpClient();
            smtpServer.Host = "smtp.gmail.com";
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.Credentials = new NetworkCredential("qiscmapp@gmail.com", "gkrikvoauqlshyzg");

            smtpServer.Timeout = 20000;

            try
            {
                smtpServer.Send(mail);
                //return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                // return "Fail Has error" + ex.Message;
            }

            smtpServer.Send(mail);
        }

        public async Task<Student> UpdateAsync(Student entity)
        {
            return await _repository.UpdateAsync(entity, true);
        }
        public async Task PasswordMigration()
        {
            var parameters = new Dictionary<string, object>();
            var students = await _repository.ExecuteStoredProcAsync<Student>(StoredProcedures.PasswordMigration, parameters);

            foreach (var student in students)
            {
                if (student.PlainPassword != null)
                {
                    student.EncrytedPassword = PasswordHelper.Encrypt(student.PlainPassword, _examPortalSettings.EncryptionKey);
                    await UpdateAsync(student);
                }
            }
        }

    }
}
