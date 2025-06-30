using ForYou.Domain.Entities;
using ForYou.SharedServices.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.SharedServices.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task<string> SendEmailAsync(string recipientEmail, string subject)
        {

            string solutionRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\.."));
            string templatePath = Path.Combine(solutionRoot, "ForYou.Infrastructure", "Email", "Templates", "NewPostNotification.html");



            string emailBody = await File.ReadAllTextAsync(templatePath);

            var smtpHost = _smtpSettings.Host; 
            var smtpPort = _smtpSettings.Port; 
            var smtpUser = _smtpSettings.User;
            var smtpPass = _smtpSettings.Password;

            using ( var Client = new SmtpClient(smtpHost, smtpPort)) {

                Client.Credentials = new NetworkCredential(smtpUser, smtpPass);

                var mailMessage = new MailMessage {

                    From = new MailAddress(recipientEmail),
                    Subject = subject,
                    Body = emailBody,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(recipientEmail);

                try
                {
                    await Client.SendMailAsync(mailMessage);
                    return "Email sent successfully.";

                }
                catch (Exception ex) {

                    return "Failed to send email.";
                }

            }
        }
    }
}
