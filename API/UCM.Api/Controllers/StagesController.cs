using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UCM.Business.Stage;
using UCM.Business.Stage.Models;

namespace UCM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StagesController : ControllerBase
    {
        private readonly IStageService _stageService;

        public StagesController(IStageService stageService)
        {
            _stageService = stageService;
        }

        [HttpGet(Name = "GetAllStages")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _stageService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("Current")]
        public async Task<IActionResult> GetCurrentStage()
        {
            var result = await _stageService.GetLastStage();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetStageById")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _stageService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StageCreateModel stageCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _stageService.AddAsync(stageCreateModel);

            return CreatedAtRoute("GetStageById", new { id = result }, result);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> Post([FromBody] IEnumerable<StageCreateModel> stageCreateModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var results = await _stageService.AddAsync(stageCreateModels);

            return CreatedAtRoute("GetAllApplication", results);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] StageCreateModel stageCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _stageService.UpdateAsync(id, stageCreateModel);

            if (result == Guid.Empty)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _stageService.DeleteAsync(id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] IEnumerable<Guid> ids)
        {
            await _stageService.DeleteAsync(ids);
            return NoContent();
        }
    }
}