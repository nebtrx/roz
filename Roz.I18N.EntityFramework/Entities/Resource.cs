using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Roz.Data;

namespace Roz.I18N.EntityFramework.Entities
{
    [Table("Resource", Schema = "I18N")]
    public class Resource : EntityConcurrentlyUnsafe
    {
        public virtual string Key { get; set; }

        public virtual ICollection<ResourceValue> Values { get; set; }
    }
}
