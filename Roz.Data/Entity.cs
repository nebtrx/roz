using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Roz.Utilities.ObjectUtils;

namespace Roz.Data
{
    [Serializable]
    public abstract class EntityWithKeyConcurrentlyUnsafe<TId> : ValidatableObject, IEntityWithKey<TId>
    {
        /// <summary>
        ///     To help ensure hash code uniqueness, a carefully selected random number multiplier 
        ///     is used within the calculation.  Goodrich and Tamassia's Data Structures and
        ///     Algorithms in Java asserts that 31, 33, 37, 39 and 41 will produce the fewest number
        ///     of collissions.  See http://computinglife.wordpress.com/2008/11/20/why-do-hash-functions-use-prime-numbers/
        ///     for more information.
        /// </summary>
        private const int HashMultiplier = 31;

        private int? _cachedHashcode;

        [Key]
        [XmlIgnore]
        public virtual TId Id { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as EntityWithKeyConcurrentlyUnsafe<TId>);
        }

        private static bool IsTransient(EntityWithKeyConcurrentlyUnsafe<TId> obj)
        {
            return obj != null && Equals(obj.Id, default(TId));
        }

        private bool HasSameNonDefaultIdAs(EntityWithKeyConcurrentlyUnsafe<TId> other)
        {
            return !this.IsTransient() && !other.IsTransient() && this.Id.Equals(other.Id);
        }

        // <summary>
        ///     Returns the signature properties that are specific to the type of the current object.
        /// 
        /// <remarks>
        ///     If you choose NOT to override this method (which will be the most common scenario), 
        ///     then you should decorate the appropriate property(s) with the <see cref="DomainSignatureAttribute"/>
        ///     attribute and they will be compared automatically. This is the preferred method of
        ///     managing the domain signature of entity objects. This ensures that the entity has at
        ///     least one property decorated with the <see cref="DomainSignatureAttribute"/> attribute.
        /// </remarks>
        protected override IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties()
        {
            return
                this.GetType().GetProperties().Where(
                    p => Attribute.IsDefined(p, typeof(DomainSignatureAttribute), true));
        }

        private System.Type GetUnproxiedType()
        {
            return GetType();
        }

        public virtual bool Equals(EntityWithKeyConcurrentlyUnsafe<TId> other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (HasSameNonDefaultIdAs(other))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
            }
            // Since the Ids aren't the same, both of them must be transient to 
            // compare domain signatures; because if one is transient and the 
            // other is a persisted entity, then they cannot be the same object.
            return this.IsTransient() && other.IsTransient() && this.HasSameObjectSignatureAs(other);
        }

        public virtual bool IsTransient()
        {
            return Id == null || Id.Equals(default(TId));
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        /// <remarks>
        ///     This is used to provide the hash code identifier of an object using the signature
        ///     properties of the object; although it's necessary for NHibernate's use, this can
        ///     also be useful for business logic purposes and has been included in this base
        ///     class, accordingly. Since it is recommended that GetHashCode change infrequently,
        ///     if at all, in an object's lifetime, it's important that properties are carefully
        ///     selected which truly represent the signature of an object.
        /// </remarks>
        public override int GetHashCode()
        {
            if (_cachedHashcode.HasValue)
            {
                return this._cachedHashcode.Value;
            }

            if (IsTransient())
            {
                _cachedHashcode = base.GetHashCode();
            }
            else
            {
                unchecked
                {
                    // It's possible for two objects to return the same hash code based on 
                    // identically valued properties, even if they're of two different types, 
                    // so we include the object's type in the hash calculation
                    var hashCode = this.GetType().GetHashCode();
                    _cachedHashcode = (hashCode * HashMultiplier) ^ this.Id.GetHashCode();
                }
            }

            return this._cachedHashcode.Value;
        }
    }

    [Serializable]

    public abstract class EntityWithKeyConcurrentlySafe<TId> : EntityWithKeyConcurrentlyUnsafe<TId>, IEntityVersionable
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    

    [Serializable]
    public abstract class EntityConcurrentlyUnsafe : EntityWithKeyConcurrentlyUnsafe<long>
    {

    }

    [Serializable]
    public abstract class Entity : EntityWithKeyConcurrentlySafe<long>
    {
    }


}
