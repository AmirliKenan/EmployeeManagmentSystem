using EmployeeManagmentSystem.Data.Entities;
using EmployeeManagmentSystem.Models;

namespace EmployeeManagmentSystem.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<IEnumerable<Employee>> GetFilteredAndPagingEmployees(Paginator paginator, string departmentName);
        Task<Employee> GetEmployeeById(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task<Employee> UpdateEmployee(Employee employee);
    }
}
