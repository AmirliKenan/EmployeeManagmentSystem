using AutoMapper;
using EmployeeManagmentSystem.Data.Entities;
using EmployeeManagmentSystem.DTOs.DepartmentDto;
using EmployeeManagmentSystem.DTOs.EmployeeDto;

namespace EmployeeManagmentSystem.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Department
            CreateMap<DepartmentAddDto, Department>().
           ForMember(dest => dest.CreateDate, opt => opt.MapFrom(x => DateTime.Now));
            //Employee
            CreateMap<Employee, EmployeeToReturnDto>()
            .ForMember(d => d.Department, o => o.MapFrom(s => s.Department.Name));
        }
      
    }
}
