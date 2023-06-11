using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Signify.Models;
using server.Data;
using server.Utility.ApiRoute;

namespace server.Controllers
{
    [Route(GetApiRoute.DefaultRoute)]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly DataContext _context;

        public AttendanceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendances()
        {
          if (_context.Attendances == null)
          {
              return NotFound();
          }
            return await _context.Attendances.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Attendance>> PostAttendance(Attendance attendance)
        {
          if (_context.Attendances == null)
          {
              return Problem("Entity set 'DataContext.Attendances'  is null.");
          }
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendance", new { id = attendance.Id }, attendance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance([FromRoute] Guid id)
        {
            if (_context.Attendances == null)
            {
                return NotFound();
            }
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceExists(Guid id)
        {
            return (_context.Attendances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
