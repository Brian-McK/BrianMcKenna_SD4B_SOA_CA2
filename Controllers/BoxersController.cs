using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public BoxersController(IBoxerRepository boxerRepository, IMapper mapper)
        {
            _boxerRepository = boxerRepository;
            _mapper = mapper;
        }

        // GET: api/Boxers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boxer>>> GetBoxers()
        {
            var items = await _boxerRepository.GetAllBoxersAsync();

            if (!items.Any())
            {
                return NotFound();
            }
            
            var boxersList = _mapper.Map<IEnumerable<BoxerDto>>(items);

            return Ok(boxersList);
        }

        // GET: api/Boxers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boxer>> GetBoxer(Guid id)
        {
            var item = await _boxerRepository.GetBoxerByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            
            var boxer = _mapper.Map<BoxerDto>(item);

            return Ok(boxer);
        }

        // PUT: api/Boxers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoxer(Guid id, BoxerForUpdatingDto boxerForUpdating)
        {
            if (!_boxerRepository.BoxerExists(id))
            {
                return BadRequest();
            }
            
            var boxerEntity = _mapper.Map<Boxer>(boxerForUpdating);

            boxerEntity.Id = id;

            await _boxerRepository.UpdateBoxerAsync(boxerEntity);

            return Ok(boxerForUpdating);
        }

        // POST: api/Boxers
        [HttpPost]
        public async Task<ActionResult<Boxer>> PostBoxer(BoxerForCreatingDto boxerForCreating)
        {
            var boxerEntity = _mapper.Map<Boxer>(boxerForCreating);
            
            await _boxerRepository.InsertBoxerAsync(boxerEntity);

            return CreatedAtAction(nameof(GetBoxer), new { id = boxerEntity.Id }, boxerEntity);
        }

        // DELETE: api/Boxers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoxer(Guid id)
        {
            await _boxerRepository.DeleteBoxerAsync(id);

            return NoContent();
        }
    }
}
