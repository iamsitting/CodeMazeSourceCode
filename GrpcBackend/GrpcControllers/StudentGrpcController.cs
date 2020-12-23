using AutoMapper;
using Grpc.Core;
using SharedLibrary.Data;
using SharedGRPC = SharedLibrary.Grpc;
using System;
using System.Threading.Tasks;

namespace GrpcBackend.GrpcControllers
{
    public class StudentGrpcController : SharedGRPC.StudentService.StudentServiceBase
    {
        private readonly StudentDataAccess _students;
        private readonly IMapper _mapper;
        public StudentGrpcController(StudentDataAccess students, IMapper mapper)
        {
            _students = students;
            _mapper = mapper;
        }

        public override async Task<SharedGRPC.GetStudentResponse> GetStudent(SharedGRPC.GetStudentRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Id != null)
                {
                    var student = await _students.GetByIdWithCoursesAsync(request.Id);
                    return new SharedGRPC.GetStudentResponse
                    {
                        Student = _mapper.Map<SharedGRPC.Student>(student)
                    };
                }
                else
                {
                    return new SharedGRPC.GetStudentResponse
                    {
                        Error = "ID is null or empty"
                    };
                }
            }
            catch (Exception ex)
            {
                return new SharedGRPC.GetStudentResponse
                {
                    Error = $"{ex.Message}"
                };
            }
        }
    }
}