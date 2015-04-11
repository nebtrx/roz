using System.ComponentModel.DataAnnotations.Schema;

namespace Roz.Data.Model.Entities
{
    [Table("EventCategory", Schema = "Domain")]
    public class EventCategoryLookup:LookupEntity<EventCategory>
    {
        public EventCategoryLookup() : base(i => ((EventCategory)i))
        {
        }
    }
}