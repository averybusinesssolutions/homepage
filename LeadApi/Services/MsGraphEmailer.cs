using Azure.Identity;
using BlazorApp.Client.Models;
using Microsoft.Graph;

namespace LeadApi.Services
{
    public class MsGraphEmailer : IEmailSender
    {
        private string[] _scopes = { "https://graph.microsoft.com/.default" };
        private IConfiguration _configuration;
        private GraphServiceClient _graph;

        private record AzureAdRegistration {
            public string Tenant { get; set; } 
            public string ClientId { get; set; } 
            public string ClientSecret { get; set; }
        };
        public MsGraphEmailer(IConfiguration configuration)
        {
            _configuration = configuration;
            AzureAdRegistration reg = new AzureAdRegistration();
            _configuration.GetSection("AzureAD").Bind(reg);

            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            ClientSecretCredential credential = new ClientSecretCredential(reg.Tenant, reg.ClientId, reg.ClientSecret, options);
            _graph = new GraphServiceClient(credential, _scopes);
        }
        public async Task SendLead(Lead lead)
        {
            var message = new Message()
            {
                Subject = "New Lead",
                ToRecipients = new List<Recipient>() { new Recipient { EmailAddress = new EmailAddress {  Address = "scott@averybusiness.net" } } },
                Body = new ItemBody() { Content = lead.ToString(), ContentType = BodyType.Html}
            };
            var user = await _graph.Users["23ae9124-b622-4260-a18e-9304b81fda8c"].Request().GetAsync();
            Console.Write(user.UserPrincipalName);
        }
    }
}
