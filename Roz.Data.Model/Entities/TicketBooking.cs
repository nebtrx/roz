using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Roz.Utilities;

namespace Roz.Data.Model.Entities
{
    [Table("TicketBooking", Schema = "Domain")]
    public class TicketBooking:EntityConcurrentlyUnsafe
    {
        [ForeignKey("Seat")]
        public long SeatId { get; set; }
        public Seat Seat { get; set; }


        [ForeignKey("Appointment")]
        public long AppointmentId { get; set; }
        public EventAppointment Appointment { get; set; }


        [ForeignKey("Venue")]
        public long VenueId { get; set; }
        public Venue Venue { get; set; }


        [ForeignKey("Booking")]
        public long BookingId { get; set; }
        public Booking Booking { get; set; }


        [ForeignKey("AttendeeDetails")]
        public long? AttendeeDetailsId { get; set; }
        public CustomerDetails AttendeeDetails { get; set; }


        [NotMappedAttribute]
        public Ticket Ticket
        {
            get { return Seat.NotNull().Tickets.FirstOrDefault(ticket => ticket.TicketBookingId == Id); }
        }
    }
}