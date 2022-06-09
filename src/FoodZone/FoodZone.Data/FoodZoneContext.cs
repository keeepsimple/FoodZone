using FoodZone.Models.Common;
using FoodZone.Models.Sercurity;
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


    }
}
