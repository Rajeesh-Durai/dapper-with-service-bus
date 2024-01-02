using AutoMapper;
using Student.Application.Features.Student.Command;
using Student.Application.View_Model;
using Student.Domain.Models;

namespace Student.Application.Mapper
{
    public class StudentMappingProfile: Profile
    {
       public StudentMappingProfile() 
        {
            CreateMap<Students, StudentResponse>().ReverseMap();
            CreateMap<Students, CreateStudentCommand>().ReverseMap();
            CreateMap<Students, UpdateStudentCommand>().ReverseMap();
        }
    }
}
