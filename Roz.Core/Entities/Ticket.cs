using System;

namespace Roz.Core.Entities
{
    public class Ticket
    {
        public Guid Guid { get; set; }

        public TicketBooking TicketBooking { get; set; }

        public EventAppointment Appointment { get; set; }

        public CustomerDetails AttendeeDetails { get; set; }

    }
}
