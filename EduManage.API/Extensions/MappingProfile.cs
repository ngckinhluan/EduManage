using AutoMapper;
using EduManage.BusinessObjects.DTOs.Request;
using EduManage.BusinessObjects.DTOs.Response;
using EduManage.BusinessObjects.Entities;

namespace EduManage.API.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // RequestDto Mapping
            CreateMap<Course, CourseRequestDto>().ReverseMap();
            CreateMap<Student, StudentRequestDto>().ReverseMap();
            CreateMap<Enrollment, EnrollmentRequestDto>().ReverseMap();
            CreateMap<Lecturer, LecturerRequestDto>().ReverseMap();
            CreateMap<LecturerCourse, LecturerCourseRequestDto>().ReverseMap();
            CreateMap<Role, RoleRequestDto>().ReverseMap();

            // ResponseDto Mapping
            CreateMap<Course, CourseResponseDto>().ReverseMap();
            CreateMap<Student, StudentResponseDto>().ReverseMap();
            CreateMap<Enrollment, EnrollmentResponseDto>().ReverseMap();
            CreateMap<Lecturer, LecturerResponseDto>().ReverseMap();
            CreateMap<LecturerCourse, LecturerCourseResponseDto>().ReverseMap();
            CreateMap<Role, RoleResponseDto>().ReverseMap();
        }
    }
}
