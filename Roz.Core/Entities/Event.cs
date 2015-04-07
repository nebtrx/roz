using System;
using System.Collections.Generic;
using Roz.Identity.EntityFramework;

namespace Roz.Core.Entities
{
    public class Event
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// IVA percent
        /// </summary>
        public decimal VATRate { get; set; }


        /// <summary>
        /// Descuento si registrado
        /// </summary>
        public EventCategory Category { get; set; }

        public ICollection<Venue> AvailableVenues { get; set; }

        /// <summary>
        /// Indicates if the event has a general allocation plan or a seating plan
        /// </summary>
        public AllocationType AllocationType { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public User Owner { get; set; }
    }
}