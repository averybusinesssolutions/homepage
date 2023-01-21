using BlazorApp.Client.Interfaces;
using BlazorApp.Client.Models;
using System.Net.Http.Json;

namespace BlazorApp.Client.Services
{
    public class LeadService : ILeadService
    {
        private readonly HttpClient _http;
        public LeadService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> NewLead(Lead lead)
        {
            return await _http.PostAsJsonAsync("/api/lead/new", lead);
        }
    }
}
