using AutoMapper;
using SharedLibrary.Grpc;
using SharedLibrary.Data;
namespace RestBackend.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<SharedLibrary.Data.Course, SharedLibrary.Grpc.Course>();
            CreateMap<SharedLibrary.Data.Student, SharedLibrary.Grpc.Student>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.CourseList));
        }
    }
}