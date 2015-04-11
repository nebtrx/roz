using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Roz.Utilities;

namespace Roz.Data.Model.Entities
{
    [Table("Section", Schema = "Domain")]
    public class Section:EntityConcurrentlyUnsafe
    {

        public string Description { get; set; }

        public string GraphicRepresentation { get; set; }

        public long SeatsAllocated { get; set; }

        [ForeignKey("DiscountType")]
        public int DiscountTypeId { get; set; }
        public DiscountTypeLookup DiscountType { get; set; }


        [ForeignKey("Venue")]
        public long VenueId { get; set; }
        public Venue Venue { get; set; }

        [InverseProperty("Section")]
        public ICollection<PriceCategory> AvailablePriceCategories { get; set; }

        [InverseProperty("Section")]
        public ICollection<Seat> Seats { get; set; }

        [NotMapped]
        public IEnumerable<TicketBooking> TicketBookings
        {
            get
            {
                var result = new List<TicketBooking>();
                Seats.NotNull().ForEach(seat => result.AddRange(seat.TicketBookings.NotNull()));
                return result;
            }
        }

        [NotMapped]
        public IEnumerable<Ticket> Tickets
        {
            get
            {
                return TicketBookings.Select(booking => booking.Ticket).WhereNotNull();
            }
        }
    }
}