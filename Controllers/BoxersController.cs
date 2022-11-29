using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrianMcKenna_SD4B_SOA_CA2.Entities;
using BrianMcKenna_SD4B_SOA_CA2.Models;
using BrianMcKenna_SD4B_SOA_CA2.Services;

namespace BrianMcKenna_SD4B_SOA_CA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxersController : ControllerBase
    {
        private readonly IBoxerRepository _boxerRepository;

        public BoxersController(IBoxerRepository boxerRepository)
        {
            _boxerRepository = boxerRepository;
        }

        // GET: api/Boxers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boxer>>> GetBoxers()
        {
            var result = await _boxerRepository.GetAllBoxersAsync();

            var boxersList = result.ToList();
            
            if (!boxersList.Any())
            {
                return NotFound();
            }

            return boxersList;
        }

        // GET: api/Boxers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boxer>> GetBoxer(Guid id)
        {
            var boxer = await _boxerRepository.GetBoxerByIdAsync(id);

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

            await _boxerRepository.UpdateBoxerAsync(boxer);

            return NoContent();
        }

        // POST: api/Boxers
        [HttpPost]
        public async Task<ActionResult<Boxer>> PostBoxer(Boxer boxer)
        {
            await _boxerRepository.InsertBoxerAsync(boxer);

            return CreatedAtAction(nameof(GetBoxer), new { id = boxer.Id }, boxer);
        }

        // DELETE: api/Boxers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoxer(Guid id)
        {
            await _boxerRepository.DeleteBoxerAsync(id);

            return Accepted();
        }
    }
}
