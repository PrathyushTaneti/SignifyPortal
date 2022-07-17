using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveMeetingsController : ControllerBase
    {
        public readonly IActiveMeetingsService activeMeetingsService;
        public ActiveMeetingsController(IActiveMeetingsService activeMeetingsService)
        {
            this.activeMeetingsService = activeMeetingsService;
        }

        [HttpGet]
        public List<ActiveMeetings> Get()
        {
            return this.activeMeetingsService.GetAllActiveMeetings();
        }

        [HttpGet("id")]
        public ActiveMeetings Get(int id)
        {
            return this.activeMeetingsService.GetMeetingById(id);
        }

        [HttpPost]
        public int Post(ActiveMeetings activeMeeting)
        {
            return this.activeMeetingsService.CreateMeeting(activeMeeting);
        }

        [HttpPut("id")]
        public bool Put(int id, ActiveMeetings activeMeetings)
        {
            return this.activeMeetingsService.UpdateMeeting(id, activeMeetings);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.activeMeetingsService.DeleteMeeting(id);
        }
    }
}
