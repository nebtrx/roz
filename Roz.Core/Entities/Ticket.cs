using System;

namespace Roz.Core.Entities
{
    public class Ticket
    {
        public long Id { get; set; }

        public Guid Guid { get; set; }

        public AllocationSection AllocationSection { get; set; }

        public PriceCategory PriceCategory { get; set; }

        public EventDate EventDate { get; set; }

    }
}
