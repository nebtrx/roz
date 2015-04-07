using System;
using System.Collections.Generic;

namespace Roz.Core.Entities
{
    public class AllocationSection
    {
        public Guid Guid { get; set; }

        public string Description { get; set; }

        public long TicketsAllocated { get; set; }

        public DiscountType Discount { get; set; }

        public Venue Venue { get; set; }

        public ICollection<ReservationOrder> ReservationOrders { get; set; }

        public ICollection<PriceCategory> AvailablePriceCategories { get; set; }

        public IEnumerable<Ticket> BookedTickets
        {
            get { throw new NotImplementedException(); }
        }
    }
}