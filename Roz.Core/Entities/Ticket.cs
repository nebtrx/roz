using System;

namespace Roz.Core.Entities
{
    public class Ticket
    {
        public Guid Guid { get; set; }

        public ReservationOrder ReservationOrder { get; set; }

        public EventAppointment Appointment { get; set; }

    }
}
