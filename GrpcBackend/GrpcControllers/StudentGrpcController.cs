using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using SharedLibrary.Data;
using SharedLibrary.GRPC;
using System;
using System.Threading.Tasks;

namespace GrpcBackend.GrpcControllers
{
    public class StudentGrpcController : StudentService.StudentServiceBase
    {
        private readonly StudentDataAccess _students;
        private readonly IMapper _mapper;
        public StudentGrpcController(StudentDataAccess students, IMapper mapper)
        {
            _students = students;
            _mapper = mapper;
        }

        public override async Task<GetStudentResponse> GetStudent(GetStudentRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Id != null)
                {
                    var student = await _students.GetByIdWithCoursesAsync(request.Id);
                    return new GetStudentResponse
                    {
                        Student = _mapper.Map<Student>(student)
                    };
                }
                else
                {
                    return new GetStudentResponse
                    {
                        Error = "ID is null or empty"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetStudentResponse
                {
                    Error = $"{ex.Message}"
                };
            }
        }
    }
}