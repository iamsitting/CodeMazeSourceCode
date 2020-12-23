using AutoMapper;
using SharedLibrary.Grpc;
using SharedLibrary.Data;
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