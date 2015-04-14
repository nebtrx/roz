using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("AllocationType", Schema = "Domain")]
    public class AllocationTypeLookup:LookupEntity<AllocationType>
    {
        public AllocationTypeLookup() : base(i => ((AllocationType)i))
        {
        }

        [InverseProperty("AllocationType")]
        public ICollection<Event> Events { get; set; }
    }
}