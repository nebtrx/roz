using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roz.Data
{

    public abstract class LookupEntity<TEnum> : EntityWithKeyConcurrentlyUnsafe<int> 
        where TEnum : struct, IComparable, IFormattable, IConvertible
    {
        private readonly Func<int, TEnum> _valueResolver;

        protected LookupEntity(Func<int, TEnum> valueResolver)
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enumerated type");
            }
            _valueResolver = valueResolver;
        }

        public string Name { get; set; }

        [NotMapped]
        public TEnum Value
        {
            get { return _valueResolver(Id); }
        }
    }
}
