using EmployeeManagmentSystem.Data;
using EmployeeManagmentSystem.Data.Entities;
using EmployeeManagmentSystem.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentSystem.Repositories.Concrete
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmpManagmentContext _context;

        public EmployeeRepository(EmpManagmentContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.Include(d => d.Department).ToListAsync();
        }
    }
}
