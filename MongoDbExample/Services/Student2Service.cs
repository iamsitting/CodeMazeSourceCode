using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using StudentGrpcService;

namespace MongoDbExample.Services
{
    public class Student2Service : Students.StudentsBase
    {
        private readonly ILogger<Student2Service> _logger;
        private readonly StudentService _studentService;
        private readonly CourseService _courseService;
        public Student2Service(ILogger<Student2Service> logger, StudentService sService, CourseService cService)
        {
            _logger = logger;
            _studentService = sService;
            _courseService = cService;
        }

        public override Task<GetStudentResponse> GetStudent(GetStudentRequest request, ServerCallContext context)
        {
            Console.WriteLine(request.Id);
            Console.WriteLine(request.ToString());
            if(request.Id != null)
            {
                var task = _studentService.GetByIdAsync(request.Id);
                task.Wait();
                Models.Student student = task.Result;
                Student s = new Student(){
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Major = student.Major,
                };
                return Task.FromResult(new GetStudentResponse
                {
                    Student = s
                });
            } else {
                return Task.FromResult(new GetStudentResponse
                {
                    Error = "ID is null or empty"
                });
            }
        }
    }
}
