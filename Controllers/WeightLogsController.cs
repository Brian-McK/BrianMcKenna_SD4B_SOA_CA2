using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrianMcKenna_SD4B_SOA_CA2.Entities;
using BrianMcKenna_SD4B_SOA_CA2.Models;

namespace BrianMcKenna_SD4B_SOA_CA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightLogsController : ControllerBase
    {
        private readonly BoxingClubContext _context;

        public WeightLogsController(BoxingClubContext context)
        {
            _context = context;
        }

        // GET: api/WeightLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeightLog>>> GetWeightLogs()
        {
          if (_context.WeightLogs == null)
          {
              return NotFound();
          }
          return await _context.WeightLogs.ToListAsync();
        }

        // GET: api/WeightLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeightLog>> GetWeightLog(Guid id)
        {
          if (_context.WeightLogs == null)
          {
              return NotFound();
          }
          var weightLog = await _context.WeightLogs.FindAsync(id);

            if (weightLog == null)
            {
                return NotFound();
            }

            return weightLog;
        }

        // PUT: api/WeightLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeightLog(Guid id, WeightLog weightLog)
        {
            if (id != weightLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(weightLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeightLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeightLogs
        [HttpPost]
        public async Task<ActionResult<WeightLog>> PostWeightLog(WeightLog weightLog)
        {
          if (_context.WeightLogs == null)
          {
              return Problem("Entity set 'BoxingClubContext.WeightLogs'  is null.");
          }
          _context.WeightLogs.Add(weightLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWeightLog), new { id = weightLog.Id }, weightLog);
        }

        // DELETE: api/WeightLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeightLog(Guid id)
        {
            if (_context.WeightLogs == null)
            {
                return NotFound();
            }
            var weightLog = await _context.WeightLogs.FindAsync(id);
            if (weightLog == null)
            {
                return NotFound();
            }

            _context.WeightLogs.Remove(weightLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeightLogExists(Guid id)
        {
            return (_context.WeightLogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
