using System;

namespace Roz.Core.Entities
{
    class Booking
    {
        public AllocationSection AllocationSection { get; set; }

        public long Id { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime ReservationTime { get; set; }

    }
}