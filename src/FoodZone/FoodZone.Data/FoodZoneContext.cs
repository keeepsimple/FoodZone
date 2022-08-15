using FoodZone.Models.BaseEntities;
using FoodZone.Models.Common;
using FoodZone.Models.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Threading;

namespace FoodZone.Data
{
    public class FoodZoneContext: IdentityDbContext<User>
    {
        public FoodZoneContext(): base("FoodZoneCnn")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        static FoodZoneContext()
        {
            // Set the database initializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<FoodZoneContext>(new DbInitializer());
        }

        public static FoodZoneContext Create()
        {
            return new FoodZoneContext();
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationDetail> ReservationDetails { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<UserVoucher> UserVouchers { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(i => i.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(i => i.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.RoleId, i.UserId });

            modelBuilder.Entity<User>().Ignore(c => c.AccessFailedCount)
                                       .Ignore(c => c.LockoutEnabled)
                                       .Ignore(c => c.LockoutEndDateUtc)
                                       .Ignore(c => c.TwoFactorEnabled)
                                       .Ignore(c => c.EmailConfirmed)
                                       .Ignore(c => c.PhoneNumberConfirmed);
            
            modelBuilder.Entity<User>().ToTable("Users");
        }

        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            BeforeSaveChanges();
            return await base.SaveChangesAsync();
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
