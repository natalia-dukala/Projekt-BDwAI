using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reservations.Models;

namespace Reservations.Controllers
{
    public class ReservationsDbContext : IdentityDbContext<DefaultUser>
    {
        public ReservationsDbContext(DbContextOptions<ReservationsDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>().HasOne(r => r.User).WithMany().HasForeignKey(r => r.UserId);
        }
    }
}
