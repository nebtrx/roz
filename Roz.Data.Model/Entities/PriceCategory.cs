using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("PriceCategory", Schema = "Domain")]
    public class PriceCategory:EntityConcurrentlyUnsafe
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Conditions { get; set; }

        public int? MaxBookingPerTransaction { get; set; }


        [ForeignKey("Section")]
        public long SectionId { get; set; }

        public Section Section { get; set; }
    }


}