using System.ComponentModel.DataAnnotations;

namespace EmployeeManagmentSystem.DTOs.DepartmentDto
{
    public class DepartmentAddDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
