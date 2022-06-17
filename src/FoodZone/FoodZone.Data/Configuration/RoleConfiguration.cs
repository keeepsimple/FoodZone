using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodZone.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id= "850d4e33-fcb4-417b-b738-67edfb69d5ee",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "6db8e259-cc84-44f0-952a-20daf821a5ac",
                    Name = "Staff",
                    NormalizedName = "STAFF"
                },
                new IdentityRole
                {
                    Id= "96b48346-4528-47cb-be00-a3eeecc7b695",
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Id = "5188a7a7-5b1d-4c02-a47e-d032961253f9",
                    Name = "Owner",
                    NormalizedName = "OWNER"
                }
                );
        }
    }
}
