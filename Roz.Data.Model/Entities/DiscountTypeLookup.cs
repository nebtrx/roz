using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("DiscountType", Schema = "Domain")]
    public class DiscountTypeLookup:LookupEntity<DiscountType>
    {
        public DiscountTypeLookup() : base(i => ((DiscountType)i))
        {
        }
    }
}