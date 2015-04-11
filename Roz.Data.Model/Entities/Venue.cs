using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Roz.Identity.EntityFramework;

namespace Roz.Data.Model.Entities
{
    [Table("Venue", Schema = "Domain")]
    public class Venue:EntityConcurrentlyUnsafe
    {
        public string Name { get; set; }

        public string MainStreet { get; set; }

        public string StreetNumber { get; set; }

        public string SecondaryStreet { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Locality { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [ForeignKey("Owner")]
        public long OwnerId { get; set; }

        public User Owner { get; set; }

        public string GraphicRepresentation { get; set; }

        /// <summary>
        /// Many to Many
        /// </summary>
        public ICollection<Event> Events { get; set; }

        [InverseProperty("Venue")]
        public ICollection<Section> AvailableSections { get; set; }

        [InverseProperty("Venue")]
        public ICollection<EventAppointment> AvailableAppointments { get; set; }
    }
}