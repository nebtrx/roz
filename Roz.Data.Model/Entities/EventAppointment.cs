using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("EventAppointment", Schema = "Domain")]
    public class EventAppointment:EntityConcurrentlyUnsafe
    {

        [ForeignKey("Venue")]
        public long VenueId { get; set; }
        public Venue Venue { get; set; }

        public DateTime Date { get; set; }

        public DateTime? DoorsOpenTime { get; set; }

        public DateTime StarTime { get; set; }

        public DateTime? EndTime { get; set; }

        public DateTime SaleStartTime { get; set; }

        public DateTime SaleEndTime { get; set; }

        [InverseProperty("Appointment")]
        public ICollection<TicketBooking> TicketBookings { get; set; }
    }
}