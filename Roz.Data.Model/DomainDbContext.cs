using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roz.Data.Model.Entities;

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
