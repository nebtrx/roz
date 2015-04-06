using System;

namespace Roz.Core.Entities
{
    public class EventDate
    {
        public Guid Guid { get; set; }

        public Event Event { get; set; }

        public DateTime Date { get; set; }

        public DateTime? DoorsOpenTime { get; set; }

        public DateTime StarTime { get; set; }

        public DateTime? EndTime { get; set; }

        public DateTime SaleStartTime { get; set; }

        public DateTime SaleEndTime { get; set; }
    }
}