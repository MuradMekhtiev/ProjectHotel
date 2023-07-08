using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=HOME-PC\\SQLEXPRESS; initial catalog=HotelProject; integrated security=true; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Guest>().ToTable(tb => tb.HasTrigger("GuestDecrease"));
            builder.Entity<Guest>().ToTable(tb => tb.HasTrigger("GuestIncrease"));
            builder.Entity<Room>().ToTable(tb => tb.HasTrigger("RoomDecrease"));
            builder.Entity<Room>().ToTable(tb => tb.HasTrigger("RoomIncrease"));
            builder.Entity<Staff>().ToTable(tb => tb.HasTrigger("StaffDecrease"));
            builder.Entity<Staff>().ToTable(tb => tb.HasTrigger("StaffIncrease"));
            base.OnModelCreating(builder);
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SentMessage> SentMessages { get; set; }
        public DbSet<MessageCategory> MessageCategories { get; set; }
        public DbSet<WorkLocation> WorkLocations { get; set; }
    }
}