using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("DiscountType", Schema = "Domain")]
    public class DiscountTypeLookup:LookupEntity<DiscountType>
    {
        public DiscountTypeLookup() : base(i => ((DiscountType)i))
        {
        }

        [InverseProperty("DiscountType")]
        public ICollection<Section> Sections { get; set; }
    }
}