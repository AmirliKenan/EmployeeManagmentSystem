using EmployeeManagmentSystem.Data.Entities;

namespace EmployeeManagmentSystem.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
