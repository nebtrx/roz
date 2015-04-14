using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("EventStatus", Schema = "Domain")]
    public class EventStatusLookup:LookupEntity<EventStatus>
    {
        public EventStatusLookup() : base(i => ((EventStatus)i))
        {
        }

        [InverseProperty("EventStatus")]
        public ICollection<Event> Events { get; set; }
    }
}