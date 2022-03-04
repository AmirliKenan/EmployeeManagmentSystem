namespace EmployeeManagmentSystem.DTOs.EmployeeDto
{
    public class EmployeeToReturnDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Department { get; set; }
    }
}
