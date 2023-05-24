using DataAccess.Entity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models;
using System.Net;
using System.Net.Mail;

namespace Domain.Srvices
{
    public class MailService : IEmailSender
    {
        private readonly MailSettings _mailSettings;
        private readonly IConfiguration _configuration;

        public MailService(IOptions<MailSettings> mailSettings,
            IConfiguration configuration)
        {
            _mailSettings = mailSettings.Value;
            _configuration = configuration;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {

        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)


        {
            var message = new MailMessage();
            message.From = new MailAddress(_configuration.GetValue<string>("MailSettings:Mail"));
            message.Sender = new MailAddress(_configuration.GetValue<string>("MailSettings:Mail"));

            message.To.Add(email);


            message.Subject = subject;
            message.Body = htmlMessage;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            message.Priority = MailPriority.High;

            
            SmtpClient client = new SmtpClient(_configuration.GetValue<string>("MailSettings:Host"),
                _configuration.GetValue<int>("MailSettings:Port"));
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.Timeout = 100000;
            
           
            client.Credentials = new NetworkCredential(_configuration.GetValue<string>("MailSettings:Mail"),
                _configuration.GetValue<string>("MailSettings:Password"));

            try
            {
                client.Send(message);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

