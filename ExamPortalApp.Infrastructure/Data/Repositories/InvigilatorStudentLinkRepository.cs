using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Dtos.Params;
using ExamPortalApp.Contracts.Data.Entities;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using ExamPortalApp.Infrastructure.Constants;
using Microsoft.AspNetCore.Http;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class InvigilatorStudentLinkRepository : IInvigilatorStudentLinkRepository
    {
        private readonly IRepository _repository;
        private readonly DecodedUser? _user;

        public InvigilatorStudentLinkRepository(IRepository repository, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _user = accessor.GetLoggedInUser();
        }

        public Task<InvigilatorStudentLink> AddAsync(InvigilatorStudentLink entity)
        {
         
                //var query = _context.InvigilatorStudentLinks
                //    .Where(x => x.InvigilatorID == InvigilatorID && x.StudentID == StudentID)
                //    .Select(x => new
                //    {
                //        InvigilatorID = x.InvigilatorID,
                //        StudentID = x.StudentID,
                //        DateModifed = DateTime.Now
                //    });

                //if (query.Any())
                //{
                //    _context.InvigilatorStudentLinks
                //        .Where(x => x.InvigilatorID == InvigilatorID && x.StudentID == StudentID)
                //        .ToList()
                //        .ForEach(x =>
                //        {
                //            x.InvigilatorID = InvigilatorID;
                //            x.StudentID = StudentID;
                //            x.DateModifed = DateTime.Now;
                //        });
                //}
                //else
                //{
                //    _context.InvigilatorStudentLinks.Add(new InvigilatorStudentLink
                //    {
                //       // InvigilatorID = InvigilatorID,
                //       // StudentID = StudentID,
                //        DateModifed = DateTime.Now
                //    });
                //}

                //_context.SaveChanges();
        

            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InvigilatorStudentLink>> GetAllAsync()
        {
            //return await _repository.GetAllAsync<InvigilatorStudentLink>();
            throw new NotImplementedException();
        }

        public Task<InvigilatorStudentLink> GetAsync(int id)
        { 
            //var query = _context.Students
            //                      .Join(_context.InvigilatorStudentLinks,
            //                          st => st.Id,
            //                          isl => isl.StudentId,
            //                          (st, isl) => new { st, isl })
            //                      .Join(_context.Sectors,
            //                          stisl => stisl.st.S,
            //                          ls => ls,
            //                          (stisl, ls) => new { stisl, ls })
            //                      .GroupJoin(_context.StudentSubjects,
            //                          stislsl => stislsl.stisl.st.StudentID,
            //                          ss => ss.CandidateId,
            //                          (stislsl, ss) => new { stislsl, ss })
            //                      .SelectMany(
            //                          stislslss => stislslss.ss.DefaultIfEmpty(),
            //                          (stislslss, ss) => new { stislslss, ss })
            //                      .Select(
            //                          stislslssss => new
            //                          {
            //                              stislslssss.stislslss.stislsl.st.StudentID,
            //                              Linked = stislslssss.stislslss.stislsl.isl.StudentID == null ? "0" : "1",
            //                              stislslssss.stislslss.stislsl.st.Name,
            //                              stislslssss.stislslss.stislsl.st.Surname,
            //                              stislslssss.stislslss.stislsl.st.ExamNo,
            //                              stislslssss.stislslss.stislsl.st.IDNumber
            //                          })
            //                      .Where(st => st.CenterID == 2 &&
            //                          (st.InvigilatorID == null || st.InvigilatorID == 2)
            //                          //&&
            //                         // (SectorId == 0 || st.SectorID == SectorId) &&
            //                         // (SubjectId == 0 || st.SubjectID == SubjectId))
            //                      .OrderByDescending(st => st.Linked));

            //   //.Where(st => st.CenterID == CenterID &&
            //   //                       (st.InvigilatorID == null || st.InvigilatorID == InvigilatorID) &&
            //   //                       (SectorId == 0 || st.SectorID == SectorId) &&
            //   //                       (SubjectId == 0 || st.SubjectID == SubjectId))
            //   //                   .OrderByDescending(st => st.Linked);

            //// Executing the LINQ query
            //var result = query.ToList();

            ////return await _repository.GetAllAsync<Subject>();
            throw new NotImplementedException();
        }

        public async Task<bool> LinkStudentsAsync(InvigilatorStudentLinker linker)
        {
            if (_user is null) return false;

            try
            {
                var linkedStudents = await _repository.GetWhereAsync<InvigilatorStudentLink>(x => x.InvigilatorId == linker.UserId && 
                    x.Student != null && 
                    x.Student.CenterId == _user.CenterId);

                foreach (var studentId in linker.StudentIds)
                {
                    var linkedStudent = linkedStudents.FirstOrDefault(x => x.StudentId == studentId);

                    if (linkedStudent is not null)
                    {
                        linkedStudents = linkedStudents.Where(x => x.StudentId != studentId).ToList();
                    }
                    else
                    {
                        var link = new InvigilatorStudentLink
                        {
                            DateModifed = DateTime.Now,
                            InvigilatorId = linker.UserId,
                            StudentId = studentId
                        };

                        await _repository.AddAsync(link);
                    }
                }

                foreach (var linkedStudent in linkedStudents)
                {
                    await _repository.DeleteAsync<InvigilatorStudentLink>(linkedStudent.Id);
                }

                await _repository.CompleteAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<InvigilatorStudentLink> UpdateAsync(InvigilatorStudentLink entity)
        {
            throw new NotImplementedException();
        }
    }
}
