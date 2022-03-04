using EmployeeManagmentSystem.Data.Entities;

namespace EmployeeManagmentSystem.Repositories.Abstract
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> AddDepartment(Department department);
        Task DeleteDepartment(int departmentId);
        Task<Department> GetDepartmentById(int departmentId);
        Task<Department> UpdateDepartment(Department department);
    }
}
