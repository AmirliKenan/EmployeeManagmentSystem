using EmployeeManagmentSystem.Data.Entities;
using EmployeeManagmentSystem.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentSystem.Data
{
    public class EmpManagmentContext:DbContext
    {
        public EmpManagmentContext(DbContextOptions<EmpManagmentContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeMap());
            modelBuilder.ApplyConfiguration<Department>(new DepartmentMap());
        }
    }
}
