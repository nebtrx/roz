using System;
using System.Collections.Generic;

namespace Roz.Data.Model.Entities
{
    public class Booking
    {
        public Guid Guid { get; set; }

        public FeeType FeeType { get; set; }

        public Venue Venue { get; set; }

        public Event Event { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime ReservationTime { get; set; }

        public CustomerDetails BookerDetails { get; set; }

        public ICollection<TicketBooking> ReservationsOrders { get; set; }

        public IEnumerable<Ticket> BookedTickets
        {
            get { throw new NotImplementedException(); }
        }
    }
}