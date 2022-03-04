using EmployeeManagmentSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagmentSystem.Data.Mappings
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.CreateDate).HasDefaultValue(DateTime.Now);

            //Seed Data
            builder.HasData(
        new Department { Id = 1, Name = "IT", CreateDate = DateTime.Now },
        new Department { Id = 2, Name = "HR", CreateDate = DateTime.Now },
        new Department { Id = 3, Name = "Sales", CreateDate = DateTime.Now },
        new Department { Id = 4, Name = "Economics", CreateDate = DateTime.Now });
        }
    }
    }

