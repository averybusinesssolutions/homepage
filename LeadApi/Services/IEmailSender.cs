using BlazorApp.Client.Models;

namespace LeadApi.Services
{
    public interface IEmailSender
    {
        public Task SendLead(Lead lead);
    }
}
