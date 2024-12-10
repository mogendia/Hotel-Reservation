using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<Guest>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Guest>()
                .Property(guest=>guest.FullName)
                .HasComputedColumnSql("[FirstName] + [LastName]");

            builder.Entity<Reserve>()
                .Property(opt=>opt.TotalPrice)
                .HasComputedColumnSql("[Price] * [Days] ");
            base.OnModelCreating(builder);

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Review> Reviews { get; set; } 
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
    }
}
