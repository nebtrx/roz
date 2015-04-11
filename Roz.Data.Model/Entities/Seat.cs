using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Roz.Utilities;

namespace Roz.Data.Model.Entities
{
    [Table("Seat", Schema = "Domain")]
    public class Seat:EntityConcurrentlyUnsafe
    {
        public Guid Guid { get; set; }

        public string Row { get; set; }

        public string SeatNumber { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public SeatStatusLookup Status { get; set; }

        public bool IsWheelchairSpace { get; set; }

        public bool IsHouseReserved { get; set; }

        public bool IsAvailable { get; set; }

        public string Comment { get; set; }


        [ForeignKey("Section")]
        public long SectionId { get; set; }

        public Section Section { get; set; }


        [InverseProperty("Seat")]
        public ICollection<TicketBooking> TicketBookings { get; set; }

        [NotMapped]
        public IEnumerable<Ticket> Tickets
        {
            get { return TicketBookings.NotNull().Select(booking => booking.Ticket).WhereNotNull(); }
        }

    }
}