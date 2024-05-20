using System;
using bookingPlatform.Models;
using COMP2139_Assignment1.Models;
using COMP2139_Assignment2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>  

	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Hotels> Hotels { get; set; }

		public DbSet<Flights> Flights { get; set; }

		public DbSet<Cars> Cars { get; set; }


        public DbSet<GuestUsers> Guest { get; set; }

        public DbSet<Cart> CartItems { get; set; }

        public DbSet<FlightCart> FlightCarts { get; set; }

        public DbSet<ListingComments> ListingComments { get; set; }
        
        public DbSet<FlightComments> FlightComments { get; set; }

        public DbSet<HotelComments> HotelComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cars>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(builder);

            builder.Entity<FlightCart>()
             .HasKey(fc => new { fc.FlightID, fc.CartID }); // Configure composite primary key for flight cart junction table

            builder.Entity<FlightCart>()
                .HasOne(fc => fc.Flight)
                .WithMany(f => f.FlightCarts)
                .HasForeignKey(fc => fc.FlightID); // Configure foreign key for Flight

            builder.Entity<FlightCart>()
                .HasOne(fc => fc.Cart)
                .WithMany(c => c.FlightCarts)
                .HasForeignKey(fc => fc.CartID); // Configure foreign key for Cart

            builder.Entity<Hotels>()
                .HasOne(h => h.Cart)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.CartID); // Configure foreign key for Cart in Hotel (hotel room)

            builder.HasDefaultSchema("Identity");

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserTokens");
            });
        }
    }
}

