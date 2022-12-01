using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    public class WeightLogsController : ControllerBase
    {
        private readonly IWeightLogRepository _weightLogRepository;
        private readonly IBoxerRepository _boxerRepository;
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public WeightLogsController(IWeightLogRepository weightLogRepository, IBoxerRepository boxerRepository, ITrainerRepository trainerRepository, IMapper mapper)
        {
            _weightLogRepository = weightLogRepository;
            _boxerRepository = boxerRepository;
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        // GET: api/WeightLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeightLog>>> GetWeightLogs()
        {
            var items = await _weightLogRepository.GetAllWeightLogsAsync();

            if (!items.Any())
            {
                return NotFound();
            }
            
            var weightLogList = _mapper.Map<IEnumerable<WeightLogDto>>(items);
            
            return Ok(weightLogList);
        }

        // GET: api/WeightLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeightLog>> GetWeightLog(Guid id)
        {
            var item = await _weightLogRepository.GetWeightLogByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            
            var weightLog = _mapper.Map<WeightLogDto>(item);
            
            return Ok(weightLog);
        }

        // PUT: api/WeightLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeightLog(Guid id, WeightLogForUpdatingDto weightLogForUpdating)
        {
            if (!(_weightLogRepository).WeightLogExists(id))
            {
                return BadRequest();
            }
            
            var weightLogEntity = _mapper.Map<WeightLog>(weightLogForUpdating);

            weightLogEntity.Id = id;

            await _weightLogRepository.UpdateWeightLogAsync(weightLogEntity);

            return Ok(weightLogForUpdating);
        }

        // POST: api/WeightLogs
        [HttpPost]
        public async Task<ActionResult<WeightLog>> PostWeightLog(WeightLogForCreatingDto weightLogForCreating)
        {
            if ((!_boxerRepository.BoxerExists(weightLogForCreating.BoxerId)) || (!_trainerRepository.TrainerExists(weightLogForCreating.VerifiedByTrainerId)))
            {
                return BadRequest();
            }
            
            var weightLogEntity = _mapper.Map<WeightLog>(weightLogForCreating);
            
            await _weightLogRepository.InsertWeightLogAsync(weightLogEntity);

            return CreatedAtAction(nameof(GetWeightLog), new { id = weightLogEntity.Id }, weightLogEntity);
        }

        // DELETE: api/WeightLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeightLog(Guid id)
        {
            await _weightLogRepository.DeleteWeightLogAsync(id);

            return NoContent();
        }
    }
}
