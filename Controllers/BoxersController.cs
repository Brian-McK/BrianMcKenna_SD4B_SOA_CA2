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
    public class BoxersController : ControllerBase
    {
        private readonly BoxingClubContext _context;

        public BoxersController(BoxingClubContext context)
        {
            _context = context;
        }

        // GET: api/Boxers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boxer>>> GetBoxers()
        {
          if (_context.Boxers == null)
          {
              return NotFound();
          }
          return await _context.Boxers.ToListAsync();
        }

        // GET: api/Boxers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boxer>> GetBoxer(Guid id)
        {
          if (_context.Boxers == null)
          {
              return NotFound();
          }
          var boxer = await _context.Boxers.FindAsync(id);

            if (boxer == null)
            {
                return NotFound();
            }

            return boxer;
        }

        // PUT: api/Boxers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoxer(Guid id, Boxer boxer)
        {
            if (id != boxer.Id)
            {
                return BadRequest();
            }

            _context.Entry(boxer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoxerExists(id))
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

        // POST: api/Boxers
        [HttpPost]
        public async Task<ActionResult<Boxer>> PostBoxer(Boxer boxer)
        {
          if (_context.Boxers == null)
          {
              return Problem("Entity set 'BoxingClubContext.Boxers'  is null.");
          }
          _context.Boxers.Add(boxer);
          await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBoxer), new { id = boxer.Id }, boxer);
        }

        // DELETE: api/Boxers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoxer(Guid id)
        {
            if (_context.Boxers == null)
            {
                return NotFound();
            }
            var boxer = await _context.Boxers.FindAsync(id);
            if (boxer == null)
            {
                return NotFound();
            }

            _context.Boxers.Remove(boxer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoxerExists(Guid id)
        {
            return (_context.Boxers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
