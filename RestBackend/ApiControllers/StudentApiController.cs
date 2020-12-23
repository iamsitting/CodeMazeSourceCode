using AutoMapper;
using SharedLibrary.Data;
using SharedLibrary.Rest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RestBackend.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly StudentDataAccess _students;
        private readonly IMapper _mapper;
        public StudentApiController(StudentDataAccess students, IMapper mapper)
        {
            _students = students;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> GetById(RequestBody requestBody)
        {
            try
            {
                if (!String.IsNullOrEmpty(requestBody.Id))
                {
                    var student = await _students.GetByIdWithCoursesAsync(requestBody.Id);
                    var response = _mapper.Map<Student>(student);
                    return Ok(response);
                }
                else
                {
                    return BadRequest("ID is null or empty");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
    }
}