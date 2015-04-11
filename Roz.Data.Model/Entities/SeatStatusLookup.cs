using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("SeatStatus", Schema = "Domain")]
    public class SeatStatusLookup : LookupEntity<SeatStatus>
    {
        public SeatStatusLookup() : base(i => ((SeatStatus)i))
        {
        }
    }
}