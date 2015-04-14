using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roz.Data.Model.Entities;
using Roz.Identity.EntityFramework;
using Roz.Utilities;

namespace Roz.Data.Model
{
    public class DomainDbContext: DbContext
    {
        public DomainDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Change the name of the table to be Users instead of AspNetUsers

            modelBuilder.Entity<UserLogin>().HasKey<int>(l => l.UserId);
            modelBuilder.Entity<UserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<Event>()
                .HasMany<Venue>(s => s.AvailableVenues)
                .WithMany(c => c.Events)
                .Map(cs => cs.ToTable("EventVenue", "Domain"));

            modelBuilder.Entity<Venue>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Venue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Venue>()
                .HasMany(c => c.TicketBookings)
                .WithRequired(c => c.Venue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EventAppointment>()
                .HasMany(e => e.TicketBookings)
                .WithRequired(e => e.Appointment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerDetails>()
                .HasMany(c => c.TicketBookings)
                .WithRequired(c => c.AttendeeDetails)
                .WillCascadeOnDelete(false);

            
            modelBuilder.Entity<Seat>()
                .HasMany(c => c.TicketBookings)
                .WithRequired(c => c.Seat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SeatStatusLookup>()
                .HasMany(c => c.Seats)
                .WithRequired(c => c.Status)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<DiscountTypeLookup>()
                .HasMany(c => c.Sections)
                .WithRequired(c => c.DiscountType)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<EventCategoryLookup>()
                .HasMany(c => c.Events)
                .WithRequired(c => c.Category)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<EventStatusLookup>()
                .HasMany(c => c.Events)
                .WithRequired(c => c.EventStatus)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<AllocationTypeLookup>()
                .HasMany(c => c.Events)
                .WithRequired(c => c.AllocationType)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<FeeTypeLookup>()
                .HasMany(c => c.Bookings)
                .WithRequired(c => c.FeeType)
                .WillCascadeOnDelete(false);

        }

        public DbSet<AllocationTypeLookup> AllocationTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CustomerDetails> CustomersDetails { get; set; }
        public DbSet<DiscountTypeLookup> DiscountTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventAppointment> EventAppointments { get; set; }
        public DbSet<EventCategoryLookup> EventCategories { get; set; }
        public DbSet<FeeTypeLookup> FeeTypes { get; set; }
        public DbSet<PriceCategory> PriceCategories { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatStatusLookup> SeatStatuses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketBooking> TicketBookings { get; set; }
        public DbSet<Venue> Venues { get; set; }

    }
}
