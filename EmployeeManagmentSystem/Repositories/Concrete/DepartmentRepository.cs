using EmployeeManagmentSystem.Data;
using EmployeeManagmentSystem.Data.Entities;
using EmployeeManagmentSystem.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentSystem.Repositories.Concrete
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly EmpManagmentContext _context;

        public DepartmentRepository(EmpManagmentContext context)
        {
            this._context = context;
        }
        public async Task<Department> AddDepartment(Department department)
        {
            var result = await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var result = await _context.Departments.
                 SingleOrDefaultAsync(e => e.Id == departmentId);
            if (result != null)
            {
                _context.Departments.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int departmentId)
        {
            return await _context.Departments.
                FirstOrDefaultAsync(d => d.Id == departmentId);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            var result = await _context.Departments.FirstOrDefaultAsync(e => e.Id == department.Id);
            if (result != null)
            {
                result.Name = department.Name;
                result.CreateDate = department.CreateDate;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
