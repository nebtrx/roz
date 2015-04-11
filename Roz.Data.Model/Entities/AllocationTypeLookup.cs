using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("AllocationType", Schema = "Domain")]
    public class AllocationTypeLookup:LookupEntity<AllocationType>
    {
        public AllocationTypeLookup() : base(i => ((AllocationType)i))
        {
        }
    }
}