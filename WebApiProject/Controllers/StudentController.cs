using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Student Get()
        {
            return new Student()
            {
                Name = "John Doe",
                Grade = 10,
                LastLoggedIn = DateTime.Today,
                Major = Major.Arts,
                Enrolled = true
            };
        }
    }
}
