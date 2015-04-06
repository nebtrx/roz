using System;
using System.Threading.Tasks;
using Roz.Data.Scope;

namespace Roz.Data
{
    public interface IDataEngine
    {
        /// <summary>
        /// Determine if type inherits from Entity and it's not the Entity class and it's not an interface
        /// </summary>
        bool IsEntity(Type type);

        IDataContextScopeFactory DataContextScopeFactory { get; }

        IAmbientDataContextLocator AmbientContextLocator { get; }
    }
}