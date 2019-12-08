using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UCM.Business.Hostel;
using UCM.Business.Hostel.Models;

namespace UCM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelsController : ControllerBase
    {
        private readonly IHostelService _hostelService;

        public HostelsController(IHostelService hostelService)
        {
            _hostelService = hostelService;
        }

        [HttpGet(Name = "GetAllHostel")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _hostelService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetHostelById")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _hostelService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HostelCreateModel hostelCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _hostelService.AddAsync(hostelCreateModel);

            return CreatedAtRoute("GetHostelById", new { id = result }, result);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> Post([FromBody] IEnumerable<HostelCreateModel> hostelCreateModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var results = await _hostelService.AddAsync(hostelCreateModels);

            return CreatedAtRoute("GetAllHostel", results);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] HostelCreateModel hostelCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _hostelService.UpdateAsync(id, hostelCreateModel);

            if (result == Guid.Empty)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _hostelService.DeleteAsync(id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] IEnumerable<Guid> ids)
        {
            await _hostelService.DeleteAsync(ids);
            return NoContent();
        }
    }
}