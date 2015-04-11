using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Roz.Identity.EntityFramework;

namespace Roz.Data.Model.Entities
{
    [Table("Event", Schema = "Domain")]
    public class Event: EntityConcurrentlyUnsafe
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public bool IsActive { get; set; }

        public bool IsAttendeeDetailsRequired { get; set; }

        /// <summary>
        /// IVA percent
        /// </summary>
        public decimal VATRate { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public EventCategoryLookup Category { get; set; }

        public AllocationTypeLookup AllocationType { get; set; }


        /// <summary>
        /// Many to Many
        /// </summary>
        public ICollection<Venue> AvailableVenues { get; set; }

        [InverseProperty("Event")]
        public ICollection<Booking> Bookings { get; set; }

        [ForeignKey("Owner")]
        public long OwnerId { get; set; }
        
        public User Owner { get; set; }
    }
}