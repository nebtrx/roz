namespace Roz.Core.Entities
{
    public class PriceCategory
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Conditions { get; set; }

        public int? MaxBookingPerTransaction { get; set; }
    }


}