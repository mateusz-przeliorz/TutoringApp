using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Infrastructure.Settings;

namespace Tutoring.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSenderSettings _emailSenderSettings;

        public EmailSender(EmailSenderSettings emailSenderSettings)
        {
            _emailSenderSettings = emailSenderSettings;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            string toEmail = string.IsNullOrEmpty(email) 
                                 ? _emailSenderSettings.ToEmail : email;

            MailMessage mail = new MailMessage()
            {

            };

            return Task.FromResult(0);
        }
    }
}
