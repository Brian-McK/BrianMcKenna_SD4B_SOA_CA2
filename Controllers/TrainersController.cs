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
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public TrainersController(ITrainerRepository trainerRepository, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        // GET: api/Trainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers()
        { 
            var result = await _trainerRepository.GetAllTrainersAsync();

            var trainersList = result.ToList();
            
            if (!trainersList.Any())
            {
                return NotFound();
            }

            return trainersList;
        }

        // GET: api/Trainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer(Guid id)
        {
            var trainer = await _trainerRepository.GetTrainerByIdAsync(id);

            if (trainer == null)
            {
                return NotFound();
            }
            
            return trainer;
        }

        // PUT: api/Trainers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer(Guid id, Trainer trainer)
        {
            if (id != trainer.Id)
            {
                return BadRequest();
            }

            await _trainerRepository.UpdateTrainerAsync(trainer);

            return NoContent();
        }

        // POST: api/Trainers
        [HttpPost]
        public async Task<ActionResult<Trainer>> PostTrainer(Trainer trainer)
        {
            await _trainerRepository.InsertTrainerAsync(trainer);

            return CreatedAtAction(nameof(GetTrainer), new { id = trainer.Id }, trainer);
        }

        // DELETE: api/Trainers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(Guid id)
        {
            await _trainerRepository.DeleteTrainerAsync(id);

            return Accepted();
        }
    }
}
