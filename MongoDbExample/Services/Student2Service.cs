using AutoMapper;
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
        private readonly IMapper _mapper;
        public Student2Service(ILogger<Student2Service> logger, StudentService sService, CourseService cService,
        IMapper mapper)
        {
            _logger = logger;
            _studentService = sService;
            _courseService = cService;
            _mapper = mapper;
        }

        public override Task<GetStudentResponse> GetStudent(GetStudentRequest request, ServerCallContext context)
        {
            if(request.Id != null)
            {
                var task = _studentService.GetByIdWithCoursesAsync(request.Id);
                task.Wait();
                return Task.FromResult(new GetStudentResponse
                {
                    Student = _mapper.Map<Student>(task.Result)
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
