using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignifyAPI.Models;
using SignifyAPI.Services.ServiceInterfaces;

namespace SignifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceTrackerController : ControllerBase
    {
        public readonly IAttendanceTrackerService attendaceTrackerService;

        public AttendanceTrackerController(IAttendanceTrackerService attendaceTrackerService)
        {
            this.attendaceTrackerService = attendaceTrackerService;
        }

        [HttpGet]
        public List<AttendanceTracker> Get()
        {
            return this.attendaceTrackerService.GetAllAttendance();
        }

        [HttpGet("id")]
        public AttendanceTracker Get(int id)
        {
            return this.attendaceTrackerService.GetAttendanceById(id);
        }

        [HttpPost]
        public int Post(AttendanceTracker attendance)
        {
            return this.attendaceTrackerService.CreateAttendance(attendance);
        }

        [HttpPut]
        public bool Put(int id,AttendanceTracker attendance)
        {
            return this.attendaceTrackerService.UpdateAttendace(id,attendance);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.attendaceTrackerService.DeleteAttendance(id);
        }
    }
}
