using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("FeeType", Schema = "Domain")]
    public class FeeTypeLookup:LookupEntity<FeeType>
    {
        public FeeTypeLookup() : base(i => ((FeeType)i))
        {
        }
    }
}