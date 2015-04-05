using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Roz.Data;

namespace Roz.I18N.EntityFramework.Entities
{
    [Table("ResourceValue", Schema = "I18N")] 
    public class ResourceValue : EntityConcurrentlyUnsafe
    {
        public virtual Resource Resource { get; set; }

        [NotMapped]
        public virtual CultureInfo Culture {
            get
            {
                if (!string.IsNullOrWhiteSpace(CultureName))
                    return new CultureInfo(CultureName);
                return null;
            }
            set { CultureName = value.Name; }
        }

        public virtual string CultureName { get; set; }
        

        public virtual string Value { get; set; }
    }
}