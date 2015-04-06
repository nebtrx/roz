namespace Roz.Core.Entities
{
    public class Venue
    {
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
    }
}