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
    public class WeightLogsController : ControllerBase
    {
        private readonly IWeightLogRepository _weightLogRepository;
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public WeightLogsController(IWeightLogRepository weightLogRepository, ITrainerRepository trainerRepository, IMapper mapper)
        {
            _weightLogRepository = weightLogRepository;
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        // GET: api/WeightLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeightLog>>> GetWeightLogs()
        {
            var result = await _weightLogRepository.GetAllWeightLogsAsync();

            var weightLogList = result.ToList();
            
            if (!weightLogList.Any())
            {
                return NotFound();
            }
            
            return Ok(weightLogList);
        }

        // GET: api/WeightLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeightLog>> GetWeightLog(Guid id)
        {
            var weightLog = await _weightLogRepository.GetWeightLogByIdAsync(id);

            if (weightLog == null)
            {
                return NotFound();
            }
            
            return Ok(weightLog);
        }

        // PUT: api/WeightLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeightLog(Guid id, WeightLog weightLog)
        {
            if (id != weightLog.Id)
            {
                return BadRequest();
            }

            await _weightLogRepository.UpdateWeightLogAsync(weightLog);

            return Ok();
        }

        // POST: api/WeightLogs
        [HttpPost]
        public async Task<ActionResult<WeightLog>> PostWeightLog(WeightLog weightLog)
        {
            if ((!_weightLogRepository.WeightLogExists(weightLog.Id)) || (!_trainerRepository.TrainerExists(weightLog.VerifiedByTrainerId)))
            {
                return NotFound();
            }
            
            await _weightLogRepository.InsertWeightLogAsync(weightLog);

            return CreatedAtAction(nameof(GetWeightLog), new { id = weightLog.Id }, weightLog);
        }

        // DELETE: api/WeightLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeightLog(Guid id)
        {
            await _weightLogRepository.DeleteWeightLogAsync(id);

            return Accepted();
        }
    }
}
