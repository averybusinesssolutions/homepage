using BlazorApp.Client.Models;
using LeadApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        public LeadController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("new")]
        public async Task<IActionResult> NewLead([FromBody]Lead lead) 
        {
            await _emailSender.SendLead(lead);
            return Ok();
        }
    }
}
