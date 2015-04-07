using System;
using System.Collections.Generic;

namespace Roz.Core.Entities
{
    public class Booking
    {
        public Guid Guid { get; set; }

        public FeeType FeeType { get; set; }

        public Venue Venue { get; set; }

        public Event Event { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime ReservationTime { get; set; }

        public ICollection<ReservationOrder> ReservationsOrders { get; set; }

        public IEnumerable<Ticket> BookedTickets
        {
            get { throw new NotImplementedException(); }
        }
    }
}