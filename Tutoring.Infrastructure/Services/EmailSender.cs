using System;
using System.Collections.Generic;
using System.Net;
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

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email)
                                 ? _emailSenderSettings.ToEmail : email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSenderSettings.UsernameEmail, "Jan Kowalski")
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.Subject = "Personal Management System - " + subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(_emailSenderSettings.PrimaryDomain, _emailSenderSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSenderSettings.UsernameEmail, _emailSenderSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                //todo
            }
        }
    }
}
