using System;

namespace Roz.Data.Model.Entities
{
    public class AllocationSeat
    {
        public AllocationSection Section { get; set; }

        public string Row { get; set; }

        public string Seat { get; set; }

        public SeatState State { get; set; }

        public bool IsWheelchairSpace { get; set; }

        public bool IsHouseReserved { get; set; }

        public bool IsAvailable { get; set; }

        public string Comment { get; set; }

        public Guid Guid { get; set; }

    }
}