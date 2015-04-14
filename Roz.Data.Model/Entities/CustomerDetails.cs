using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Roz.Utilities;

namespace Roz.Data.Model.Entities
{
    [Table("CustomerDetails", Schema = "Domain")]
    public class CustomerDetails:EntityConcurrentlyUnsafe
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Position { get; set; }

        public string Organization { get; set; }

        [InverseProperty("BookerDetails")]
        public ICollection<Booking> Bookings { get; set; }

        [InverseProperty("AttendeeDetails")]
        public ICollection<TicketBooking> TicketBookings { get; set; }

        [NotMapped]
        public IEnumerable<Ticket> Tickets
        {
            get { return TicketBookings.NotNull().Select(booking => booking.Ticket).WhereNotNull(); }
        }
    }
}