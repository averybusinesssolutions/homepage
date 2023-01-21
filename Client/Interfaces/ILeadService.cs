using BlazorApp.Client.Models;

namespace BlazorApp.Client.Interfaces
{
    public interface ILeadService
    {
        public Task<HttpResponseMessage> NewLead(Lead lead);
    }
}
