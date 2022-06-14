using FoodZone.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodZone.Data.Configuration
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasData(
                new Food
                {
                    Name = "Trà Đào Cam Sả",
                    Description = "Có vị thanh ngọt của đào, vị chua dịu của những tép cam căng mọng, vị chát của trà, cùng hương thơm nồng đặc trưng của sả.",
                    MenuId = 1,
                    Price = 30000,
                    Status = 1,
                    Image = "tradaocamxa.jpg",
                    InsertedAt = DateTime.Now
                },
                new Food
                {
                    Name = "Sữa Chua Đánh Đá",
                    Description = "Vị chua chua hòa quyện với vị ngọt từ hoa quả cùng cảm giác mát lạnh từ món ăn.",
                    MenuId = 1,
                    Price = 30000,
                    Status = 1,
                    Image = "suachuadanhda.jpg",
                    InsertedAt = DateTime.Now
                },
                new Food
                {
                    Name = "Thịt Bò Kho Cà Rốt",
                    Description = "Thịt bò được kho vừa mềm mà không bị dai, cà rốt giòn ngọt thấm vị nước sốt cay cay mặn mặn đậm đà, dậy mùi thơm phức từ sả rất hấp dẫn.",
                    MenuId = 2,
                    Price = 50000,
                    Status = 1,
                    Image = "thitbokhocarot.jpg",
                    InsertedAt = DateTime.Now
                },
                new Food
                {
                    Name = "Mực Viên Tuyết Hoa",
                    Description = "Mùi vị thơm ngon và độ dai giòn của mực hòa với vị ngon của nhân bên trong. ",
                    MenuId = 2,
                    Price = 215000,
                    Status = 1,
                    Image = "mucvientuyethoa.jpg",
                    InsertedAt = DateTime.Now
                },
                new Food
                {
                    Name = "Cánh Gà Nướng Rau Củ",
                    Description = "Ướp với nước sốt đặc biệt làm món ăn ngon ngọt thơm.",
                    MenuId = 3,
                    Price = 150000,
                    Status = 1,
                    Image = "canhganuongraucu.png",
                    InsertedAt = DateTime.Now
                },
                new Food
                {
                    Name = "Sườn Heo Om Dứa",
                    Description = "Vị thơm của dứa thêm vào cho sườn heo một vị chua chua.",
                    MenuId = 3,
                    Price = 170000,
                    Status = 1,
                    Image = "suonheoomdua.png"
                },
                new Food
                {
                    Name = "Cà Tím Hấp Thịt Heo",
                    Description = "Vị thơm của cà thêm vào cho thịt heo vị ngon.",
                    MenuId = 4,
                    Price = 130000,
                    Status = 1,
                    Image = "catimhapthitheo.png"
                },
                new Food
                {
                    Name = "Đậu Phụ Om Với Tôm",
                    Description = "Vị thơm của cà thêm vào cho thịt heo vị ngon.",
                    MenuId = 4,
                    Price = 120000,
                    Status = 1,
                    Image = "dauphuomvoitom.png"
                }
                );
        }
    }
}
