using AutoMapper;
using EmployeeManagmentSystem.Data.Entities;
using EmployeeManagmentSystem.DTOs.DepartmentDto;

namespace EmployeeManagmentSystem.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<DepartmentAddDto, Department>().
           ForMember(dest => dest.CreateDate, opt => opt.MapFrom(x => DateTime.Now));

        }
      
    }
}
