using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Roz.Utilities;

namespace Roz.Data.Model.Entities
{
    [Table("Booking", Schema = "Domain")]
    public class Booking:EntityConcurrentlyUnsafe
    {
        public Guid Guid { get; set; }

        public FeeTypeLookup FeeType { get; set; }

        [ForeignKey("Venue")]
        public long VenueId { get; set; }
        public Venue Venue { get; set; }

        [ForeignKey("Event")]
        public long EventId { get; set; }
        public Event Event { get; set; }


        [ForeignKey("BookerDetails")]
        public long BookerDetailsId { get; set; }
        public CustomerDetails BookerDetails { get; set; }


        public bool IsConfirmed { get; set; }

        public DateTime ReservationTime { get; set; }

        

        [InverseProperty("Booking")]
        public ICollection<TicketBooking> TicketBookings { get; set; }

        [NotMapped]
        public IEnumerable<Ticket> BookedTickets
        {
            get { return TicketBookings.NotNull().Select(booking => booking.Ticket).WhereNotNull(); }
        }
    }
}