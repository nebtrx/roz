using System;

namespace Roz.Data.Model.Entities
{
    public class Ticket
    {
        public Guid Guid { get; set; }

        public TicketBooking TicketBooking { get; set; }

        public EventAppointment Appointment { get; set; }

        public CustomerDetails AttendeeDetails { get; set; }

    }
}
