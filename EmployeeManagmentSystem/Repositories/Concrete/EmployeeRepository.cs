using EmployeeManagmentSystem.Data;
using EmployeeManagmentSystem.Data.Entities;
using EmployeeManagmentSystem.Models;
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

        public async Task<IEnumerable<Employee>> GetFilteredAndPagingEmployees(Paginator paginator, string departmentName)
        {
            var queryable = _context.Employees.AsQueryable();
            queryable = queryable.Where(x => x.Department.Name == departmentName);
            return await queryable.Include(d => d.Department).Skip((paginator.PageNumber - 1) * paginator.PageSize)
        .Take(paginator.PageSize)
        .ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _context.Employees.
                 Include(e => e.Department).
                 FirstOrDefaultAsync(e => e.Id == employeeId);
        }
    }
}
