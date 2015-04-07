﻿using System;
using System.Collections.Generic;

namespace Roz.Core.Entities
{
    public class ReservationOrder
    {
        public int Quantity { get; set; }

        public AllocationSection AllocationSection { get; set; }

        public PriceCategory PriceCategory { get; set; }

        public EventAppointment Appointment { get; set; }

        public Booking Booking { get; set; }

        public ICollection<Ticket> BookedTickets { get; set; }
    }
}