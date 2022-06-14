using FoodZone.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodZone.Data.Configuration
{
    public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.HasData(
                new Salary
                {
                    Id = 1,
                    Name = "Nhân viên 1",
                    BasicSalary = 3000000,
                    InsertedAt = DateTime.Now,
                }, new Salary
                {
                    Id = 2,
                    Name = "Nhân viên 2",
                    BasicSalary = 4000000,
                    InsertedAt = DateTime.Now,
                }, new Salary
                {
                    Id = 3,
                    Name = "Nhân viên 3",
                    BasicSalary = 5000000,
                    InsertedAt = DateTime.Now,
                }, new Salary
                {
                    Id = 4,
                    Name = "Quản lý 1",
                    BasicSalary = 8000000,
                    InsertedAt = DateTime.Now,
                }, new Salary
                {
                    Id = 5,
                    Name = "Quản lý 2",
                    BasicSalary = 10000000,
                    InsertedAt = DateTime.Now,
                }
                );
        }
    }
}
