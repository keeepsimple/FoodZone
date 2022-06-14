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
                    Id = 1,
                    Capacity = 10,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Id = 2,
                    Capacity = 10,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Id = 3,
                    Capacity = 8,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Id = 4,
                    Capacity = 8,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Id = 5,
                    Capacity = 6,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Id = 6,
                    Capacity = 6,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Id = 7,
                    Capacity = 2,
                    Status = 1,
                    InsertedAt = DateTime.Now
                },
                new Table
                {
                    Id = 8,
                    Capacity = 2,
                    Status = 1,
                    InsertedAt = DateTime.Now
                }
                );
        }
    }
}
