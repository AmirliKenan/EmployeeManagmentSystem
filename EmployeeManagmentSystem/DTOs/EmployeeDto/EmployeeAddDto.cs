using EmployeeManagmentSystem.Data.Entities;

namespace EmployeeManagmentSystem.DTOs.EmployeeDto
{
    public class EmployeeAddDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public Department? Department { get; set; }
    }
}
