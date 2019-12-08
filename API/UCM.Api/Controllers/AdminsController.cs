using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using UCM.Business.Admin;
using UCM.Business.Admin.Models;

namespace UCM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        //[Authorize(Roles="Admin")]
        [HttpGet(Name = "GetAllAdmins")]
        public async Task<IActionResult> Get()
        {
            var admins = await _adminService.GetAllAsync("Person");

            return Ok(admins);
        }

        [HttpGet("{id}", Name = "GetAdminById")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _adminService.GetAsync(id, "Person");

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetByPerson/{id}", Name = "GetAdminByPersonId")]
        public async Task<IActionResult> GetByPersonId(Guid id)
        {
            var result = await _adminService.GetAdminByPersonId(id, "Person");

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdminCreateModel adminCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _adminService.AddAsync(adminCreateModel);

            return CreatedAtRoute("GetAdminById", new { id = result }, result);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> Post([FromBody] IEnumerable<AdminCreateModel> adminCreateModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var results = await _adminService.AddAsync(adminCreateModels);

            return CreatedAtRoute("GetAllAdmins", results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AdminCreateModel adminCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _adminService.UpdateAsync(id, adminCreateModel);

            if (result == Guid.Empty)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _adminService.DeleteAsync(id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] IEnumerable<Guid> ids)
        {
            await _adminService.DeleteAsync(ids);
            return NoContent();
        }
    }
}