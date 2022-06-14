using FoodZone.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodZone.Data.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasData(
                new Menu
                {
                    Id = 1,
                    Name = "Đồ Uống",
                    Description = "Mang lại một vị tươi mới",
                    InsertedAt = DateTime.Now
                },
                new Menu
                {
                    Id = 2,
                    Name = "Thực Đơn Theo Mùa",
                    Description = "Mỗi mùa mang đến một vị khác nhau",
                    InsertedAt = DateTime.Now
                },
                new Menu
                {
                    Id = 3,
                    Name = "Thực Đơn Tối",
                    Description = "Mùa nào cũng có",
                    InsertedAt = DateTime.Now
                },
                new Menu
                {
                    Id = 4,
                    Name = "Thực Đơn Sáng",
                    Description = "Mùa nào cũng có",
                    InsertedAt = DateTime.Now
                }
                );
        }
    }
}
