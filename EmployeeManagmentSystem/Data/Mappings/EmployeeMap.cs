using EmployeeManagmentSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagmentSystem.Data.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //Fluent API
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(50);
            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.Now);


            //Seed data
            builder.HasData(
         new Employee { Id = 1, Name = "Kenan", Surname = "Amirli", BirthDate = new DateTime(1999, 12, 31), CreateDate = DateTime.Now, DepartmentId = 1 },
         new Employee { Id = 2, Name = "Rufat", Surname = "Qedirov", BirthDate = new DateTime(2000, 10, 30), CreateDate = DateTime.Now, DepartmentId = 2 },
         new Employee { Id = 3, Name = "Fazil", Surname = "Amirli", BirthDate = new DateTime(2001, 11, 27), CreateDate = DateTime.Now, DepartmentId = 3 },
         new Employee { Id = 4, Name = "Qara", Surname = "Humbatov", BirthDate = new DateTime(1992, 7, 18), CreateDate = DateTime.Now, DepartmentId = 4 },
         new Employee { Id = 5, Name = "Nurlan", Surname = "Ramazanov", BirthDate = new DateTime(2003, 12, 31), CreateDate = DateTime.Now, DepartmentId = 4 },
         new Employee { Id = 6, Name = "Vasif", Surname = "Hasanzadeh", BirthDate = new DateTime(1998, 12, 31), CreateDate = DateTime.Now, DepartmentId = 2 },
         new Employee { Id = 7, Name = "Turqay", Surname = "Abdullayef", BirthDate = new DateTime(2000, 12, 31), CreateDate = DateTime.Now, DepartmentId = 2 },
         new Employee { Id = 8, Name = "Turqay", Surname = "Osmanli", BirthDate = new DateTime(2004, 3, 17), CreateDate = DateTime.Now, DepartmentId = 1 },
         new Employee { Id = 9, Name = "Ehmed", Surname = "Qarayev", BirthDate = new DateTime(2000, 2, 13), CreateDate = DateTime.Now, DepartmentId = 1 },
         new Employee { Id = 10, Name = "Qedir", Surname = "Babayev", BirthDate = new DateTime(2000, 1, 22), CreateDate = DateTime.Now, DepartmentId = 1 },
         new Employee { Id = 11, Name = "Hebib", Surname = "Amirli", BirthDate = new DateTime(2007, 1, 22), CreateDate = DateTime.Now, DepartmentId = 3 });
        }
    }
}
