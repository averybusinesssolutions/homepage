using BlazorApp.Client.Interfaces;
using System.Net;
using System.Net.Mail;

namespace BlazorApp.Client.Services
{
    public class GmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public GmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string from, string subject, string body)
        {
            string secret = _configuration.GetSection("Gmail").Value;

            var emailClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("scott@averybusiness.net", secret)
            };
            using (var message = new MailMessage(from, to)
            {
                Subject = subject,
                Body = body
            })
            {
                emailClient.Send(message);
            }
        }
    }
}
