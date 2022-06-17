using FoodZone.Data.Configuration;
using FoodZone.Models.BaseEntities;
using FoodZone.Models.Common;
using FoodZone.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodZone.Data
{
    public class FoodZoneContext : IdentityDbContext<Account>
    {
        public FoodZoneContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationDetail> ReservationDetails { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new MenuConfiguration());
            builder.ApplyConfiguration(new FoodConfiguration());
            builder.ApplyConfiguration(new TableConfiguration());
            builder.ApplyConfiguration(new SalaryConfiguration());

            //var passwordHash = new PasswordHasher<Account>();

            //var user = new Account
            //{
            //    Email = "owner@foodzone.com",
            //    UserName = "owner@foodzone.com",
            //    FullName = "Quang",
            //    PhoneNumber = "0985786750",
            //    Id = "fec388f4-32c6-4e2c-bae0-d3c807612c6d",
            //    PasswordHash=passwordHash.HashPassword(null,"admin123")
            //};

            //builder.Entity<Account>().HasData(user);

            //builder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>()
            //    {
            //        RoleId = "5188a7a7-5b1d-4c02-a47e-d032961253f9",
            //        UserId = "fec388f4-32c6-4e2c-bae0-d3c807612c6d"
            //    }
            //    );
        }

        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            BeforeSaveChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void BeforeSaveChanges()
        {
            var entities = this.ChangeTracker.Entries();
            foreach (var entry in entities)
            {
                if (entry.Entity is IBaseEntity entityBase)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified: entityBase.UpdatedAt = DateTime.Now; break;
                        case EntityState.Added:
                            entityBase.UpdatedAt = DateTime.Now;
                            entityBase.InsertedAt = DateTime.Now;
                            break;
                    }
                }
            }
        }
    }
}
