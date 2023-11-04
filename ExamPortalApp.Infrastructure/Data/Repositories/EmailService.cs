using ExamPortalApp.Contracts.Data.Dtos.Custom;
using ExamPortalApp.Contracts.Data.Repositories;
using ExamPortalApp.Contracts.Data.Repositories.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace ExamPortalApp.Infrastructure.Data.Repositories
{
    public class EmailService : IEmailService
    {
        private readonly ExamPortalSettings _appSettings;
        private readonly IBackgroundQueue<EmailDto> _queue;
        private readonly ILogger<IEmailService> _logger;
        public EmailService(IOptions<ExamPortalSettings> appSetting, IBackgroundQueue<EmailDto> queue, ILogger<IEmailService> logger)
        {
            _appSettings = appSetting.Value;
            _queue = queue;
            _logger = logger;
        }

        public void SendOrQueue(EmailDto input, bool isFromQueue = false)
        {
            try
            {
                if (isFromQueue)
                {
                    Send(input.EmailAddesses, input.Subject, input.MessageBody, null, input.CcAddresses, input.BccAddresses);
                }
                else
                {
                    _queue.Enqueue(input);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error sending message  {ex.Message}");
            }
        }

        private bool Send(IEnumerable<string> destinations, string subject, string message, IEnumerable<Attachment>? attachments, IEnumerable<string>? cc = null, IEnumerable<string>? bcc = null)
        {
            try
            {
                if (destinations == null || destinations?.Count() == 0) return false;
                if (_appSettings.EmailSettings == null) return false;

                _logger.LogInformation($"Sending out an email");

                #region Mail Message Setup
                MailMessage email = new MailMessage();

                email.From = new MailAddress(_appSettings.EmailSettings.Username, _appSettings.EmailSettings.DisplayName);

                if (destinations != null)
                {
                    foreach (var item in destinations)
                    {
                        email.To.Add(item);
                    }
                }

                if (cc != null)
                {
                    foreach (var item in cc)
                    {
                        email.CC.Add(item);
                    }
                }

                if (bcc != null)
                {
                    foreach (var item in bcc)
                    {
                        email.Bcc.Add(item);
                    }
                }

                if (attachments is not null)
                {
                    foreach (var item in attachments)
                    {
                        email.Attachments.Add(item);
                    }
                }

                email.Subject = subject;
                email.Body = message;
                email.IsBodyHtml = true; 
                #endregion

                #region SMTP Client
                SmtpClient mailClient = new SmtpClient(_appSettings.EmailSettings.Host, _appSettings.EmailSettings.Port);

                mailClient.Host = _appSettings.EmailSettings.Host;
                mailClient.Port = 587;
                mailClient.EnableSsl = true;
                mailClient.UseDefaultCredentials = false;
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailClient.Credentials = new NetworkCredential(_appSettings.EmailSettings.Username, _appSettings.EmailSettings.Password);
                mailClient.Send(email);
                #endregion

                _logger.LogInformation($"Sending out an email: success");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error sending a message {ex.Message}");

                return false;
            }
        }
    }
}
