using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCM.Business.Student;
using UCM.Business.Student.Models;

namespace UCM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //[Authorize(Roles="Student")]
        [HttpGet(Name = "GetAllStudents")]
        //[EnableQuery()]
        public async Task<IActionResult> Get()
        {
            var students = await _studentService.GetAllAsync("Person");

            return Ok(students);
        }

        [HttpGet("ConfirmedStudents", Name = "GetAllConfirmedStudents")]
        //[EnableQuery()]
        public async Task<IActionResult> GetAllConfirmed()
        {
            var students = await _studentService.GetAllConfirmedAsync("Person");

            return Ok(students);
        }

        [HttpGet("UnconfirmedStudents", Name = "GetAllUnconfirmedStudents")]
        //[EnableQuery()]
        public async Task<IActionResult> GetAllUnconfirmed()
        {
            var students = await _studentService.GetAllUnconfirmedAsync("Person");

            return Ok(students);
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _studentService.GetAsync(id, "Person");

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetByPerson/{id}", Name = "GetStudentByPersonId")]
        public async Task<IActionResult> GetByPersonId(Guid id)
        {
            var result = await _studentService.GetStudentByPersonId(id, "Person");

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetWithHostel/{id}", Name = "GetStudentWithHostelById")]
        public async Task<IActionResult> GetWithHostel(Guid id)
        {
            var result = await _studentService.GetWithHostelById(id, "Person");

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }



        [HttpPost("Confirmation")]
        public async Task<IActionResult> PostCofirmation([FromBody] StudentConfirmationModel studentConfirmation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentService.Confirmation(studentConfirmation);

            return CreatedAtRoute("GetStudentById", new { id = result }, result);
        }

        [HttpPost("SetStudentsGroup")]
        public async Task<IActionResult> SetStudentsGroup([FromBody] IEnumerable<StudentConfirmationModel> studentConfirmations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentService.SetStudentsGroup(studentConfirmations);

            return CreatedAtRoute("GetAllUnconfirmedStudents", new { id = result }, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateModel studentCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentService.AddAsync(studentCreateModel);

            return CreatedAtRoute("GetStudentById", new { id = result }, result);
        }


        [HttpPost("bulk")]
        public async Task<IActionResult> Post([FromBody] IEnumerable<StudentCreateModel> studentCreateModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var results = await _studentService.AddAsync(studentCreateModels);

            return CreatedAtRoute("GetAllStudents", results);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] StudentCreateModel studentCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentService.UpdateAsync(id, studentCreateModel);

            if (result == Guid.Empty)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _studentService.DeleteAsync(id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] IEnumerable<Guid> ids)
        {
            await _studentService.DeleteAsync(ids);
            return NoContent();
        }
    }
}