using BlazorApp.Client.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace LeadApi.Services
{
    public class GmailSender : IEmailSender
    {
        public async Task SendLead(Lead lead)
        {
            string[] scopes = { GmailService.Scope.GmailSend };
            GoogleCredential credential;
            using(var stream = new FileStream("./emailer.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(scopes).CreateWithUser("scott@averybusiness.net");
            }
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "lead"
            });
            string messageContent = $"To: scott@averybusiness.net\r\nSubject: New Lead\r\nContent-Type: text/html;charset=utf-8\r\n\r\n{lead.ToString()}";
            var message = new Message();
            message.Raw = Base64UrlEncode(messageContent);
            service.Users.Messages.Send(message, "me").Execute();  
        }

        private string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
    }
}
