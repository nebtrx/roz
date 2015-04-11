using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("Ticket", Schema = "Domain")]
    public class Ticket:EntityConcurrentlyUnsafe
    {
        public Guid Guid { get; set; }

        [ForeignKey("TicketBooking")]
        public long TicketBookingId { get; set; }
        public TicketBooking TicketBooking { get; set; }

    }
}
