using FoodZone.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodZone.Data.Configuration
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasData(
                new Table
                {
                    Capacity = 10,
                    Status = 1,
                    InsertedAt= DateTime.Now
                },
                new Table
                {
                    Capacity = 10,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Capacity = 8,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Capacity = 8,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Capacity = 6,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Capacity = 6,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Capacity = 2,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Capacity = 2,
                    Status = 1,
                    InsertedAt = DateTime.Now
                }
                );
        }
    }
}
