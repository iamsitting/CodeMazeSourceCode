using AutoMapper;
using SharedLibrary.Data;
using SharedLibrary.Grpc;
namespace RestBackend.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Course, StudentGrpcService.Course>();
            CreateMap<Student, StudentGrpcService.Student>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.CourseList));
        }
    }
}