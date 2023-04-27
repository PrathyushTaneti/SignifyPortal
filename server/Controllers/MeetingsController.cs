using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Signify.Models;
using server.Data;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly DataContext _context;

        public MeetingsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meeting>>> GetMeetings()
        {
          if (_context.Meetings == null)
          {
              return NotFound();
          }
            return await _context.Meetings.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Meeting>> PostMeeting(Meeting meeting)
        {
          if (_context.Meetings == null)
          {
              return Problem("Entity set 'DataContext.Meetings'  is null.");
          }
            _context.Meetings.Add(meeting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeeting", new { id = meeting.Id }, meeting);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(Guid id)
        {
            if (_context.Meetings == null)
            {
                return NotFound();
            }
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeetingExists(Guid id)
        {
            return (_context.Meetings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
