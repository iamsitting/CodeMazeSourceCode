using MongoDbExample.Models;
using MongoDbExample.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;
        public StudentsController(StudentService service)
        {
            _studentService = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Student>> GetById(string id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            await _studentService.CreateAsync(student);
            return Ok(student);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Student updatedStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var queriedStudent = await _studentService.GetByIdAsync(id);
            if(queriedStudent == null)
            {
                return NotFound();
            }
            await _studentService.UpdateAsync(id, updatedStudent);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            await _studentService.DeleteAsync(id);
            return NoContent();
        }

    }
}