using System;
using System.Collections.Generic;

namespace Roz.Data.Model.Entities
{
    public class Venue
    {
        public Guid Guid { get; set; }

        public long Id { get; set; }

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

        public string GraphicRepresentation { get; set; }

        public Event Event { get; set; }

        public ICollection<AllocationSection> AvailableAllocationSections { get; set; }

        public ICollection<EventAppointment> AvailableAppointments { get; set; }
    }
}