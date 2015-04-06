using System;
using System.Collections.Generic;

namespace Roz.Core.Entities
{
    public class Event
    {
        public long Id { get; set; }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public bool IsActive { get; set; }

        public decimal? FeeRate { get; set; }

        public decimal VATRate { get; set; }

        public EventCategory Category { get; set; }

        public decimal? DiscountIfAffiliate { get; set; }

        public Venue Venue { get; set; }

        public List<EventDate> Dates  { get; set; }

        public AllocationType AllocationType { get; set; }

        public List<AllocationSection> AllocationSections { get; set; }

        public List<PriceCategory> PriceCategories { get; set; }

        public List<Discount> Discounts { get; set; }

    }
}