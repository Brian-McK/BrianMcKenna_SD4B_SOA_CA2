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
            var items = await _trainerRepository.GetAllTrainersAsync();

            if (!items.Any())
            {
                return NotFound();
            }
            
            var trainersList = _mapper.Map<IEnumerable<TrainerDto>>(items);

            return Ok(trainersList);
        }

        // GET: api/Trainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer(Guid id)
        {
            var item = await _trainerRepository.GetTrainerByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            
            var trainer = _mapper.Map<TrainerDto>(item);

            return Ok(trainer);
        }

        // PUT: api/Trainers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer(Guid id, TrainerForUpdatingDto trainerForUpdating)
        {
            if (!(_trainerRepository).TrainerExists(id))
            {
                return BadRequest();
            }
            
            var trainerEntity = _mapper.Map<Trainer>(trainerForUpdating);

            trainerEntity.Id = id;

            await _trainerRepository.UpdateTrainerAsync(trainerEntity);

            return Ok(trainerForUpdating);
        }

        // POST: api/Trainers
        [HttpPost]
        public async Task<ActionResult<Trainer>> PostTrainer(TrainerForCreatingDto trainerForCreating)
        {
            var trainerEntity = _mapper.Map<Trainer>(trainerForCreating);
            
            await _trainerRepository.InsertTrainerAsync(trainerEntity);

            return CreatedAtAction(nameof(GetTrainer), new { id = trainerEntity.Id }, trainerEntity);
        }

        // DELETE: api/Trainers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(Guid id)
        {
            await _trainerRepository.DeleteTrainerAsync(id);

            return NoContent();
        }
    }
}
