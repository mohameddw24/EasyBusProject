using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EasyBusProject.ViewModels;

namespace EasyBus.Models
{
    public class MainDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public MainDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<UserSchedule> UserSchedules{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.PickUp)
                .WithMany(s => s.TripsAsPickUp)
                .HasForeignKey(t => t.PickUpID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.DropOff)
                .WithMany(s => s.TripsAsDropOff)
                .HasForeignKey(t => t.DropOffID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete
        }
        public DbSet<EasyBusProject.ViewModels.RegisterUserVM> RegisterUserVM { get; set; } = default!;
        public DbSet<EasyBusProject.ViewModels.LoginUserVM> LoginUserVM { get; set; } = default!;


    }
}
