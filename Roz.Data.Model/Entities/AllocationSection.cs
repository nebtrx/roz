using System;
using System.Collections.Generic;

namespace Roz.Data.Model.Entities
{
    public class AllocationSection
    {
        public Guid Guid { get; set; }

        public string Description { get; set; }

        public string GraphicRepresentation { get; set; }

        public long SeatsAllocated { get; set; }

        public DiscountType Discount { get; set; }

        public Venue Venue { get; set; }

        public ICollection<TicketBooking> TicketBookings { get; set; }

        public ICollection<PriceCategory> AvailablePriceCategories { get; set; }

        public ICollection<AllocationSeat> Seats { get; set; }

        public IEnumerable<Ticket> Tickets
        {
            get { throw new NotImplementedException(); }
        }
    }
}