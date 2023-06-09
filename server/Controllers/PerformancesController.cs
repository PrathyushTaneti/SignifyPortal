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
    [Route(IGetApiRoute.DefaultRoute)]
    [ApiController]
    public class PerformancesController : ControllerBase
    {
        private readonly DataContext _context;

        public PerformancesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Performance>>> GetPerformances()
        {
          if (_context.Performances == null)
          {
              return NotFound();
          }
            return await _context.Performances.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Performance>> PostPerformance(Performance performance)
        {
          if (_context.Performances == null)
          {
              return Problem("Entity set 'DataContext.Performances'  is null.");
          }
            _context.Performances.Add(performance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerformance", new { id = performance.Id }, performance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformance(Guid id)
        {
            if (_context.Performances == null)
            {
                return NotFound();
            }
            var performance = await _context.Performances.FindAsync(id);
            if (performance == null)
            {
                return NotFound();
            }

            _context.Performances.Remove(performance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerformanceExists(Guid id)
        {
            return (_context.Performances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
