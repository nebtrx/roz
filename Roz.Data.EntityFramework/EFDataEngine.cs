using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using Roz.Data.EntityFramework.Scope;
using Roz.Data.Scope;
using Roz.Utilities;

namespace Roz.Data.EntityFramework
{
    public class EFDataEngine : DataEngine, IEFDataEngine
    {

        private static Dictionary<string, Func<Type>> _entitiesContextRegistry;
        private static bool _entitiesAlreadyScanned;

        protected static Dictionary<string, Func<Type>> EntitiesContextRegistry
        {
            get { return _entitiesContextRegistry ?? (_entitiesContextRegistry = new Dictionary<string, Func<Type>>()); }
        }

        #region [    Private Fields    ]

        private Lazy<IDataContextScopeFactory> _dataContextScopeFactory;
        private Lazy<IAmbientDataContextLocator> _ambientContextLocator;

        #endregion
        #region [    public Properties    ]

        /// <summary>
        /// Gets the current SessionFactory and initializes lazy loaded
        /// </summary>
        public IDataContextScopeFactory DataContextScopeFactory
        {
            get { return _dataContextScopeFactory.Value; }
        }

        public IAmbientDataContextLocator AmbientContextLocator
        {
            get { return _ambientContextLocator.Value; }
        }

        

        public Type GetEntityContextType(Type entityType)
        {
            return EntitiesContextRegistry[entityType.FullName]();
        }

        public void RegisterInitializer<TContext>(IDatabaseInitializer<TContext> initializer)
            where TContext : DbContext
        {
            Database.SetInitializer(initializer);
        }


        #endregion

        #region [    Private Methods    ]

        public EFDataEngine()
        {
            _dataContextScopeFactory = new Lazy<IDataContextScopeFactory>(() => new DbContextScopeFactory());
            _ambientContextLocator = new Lazy<IAmbientDataContextLocator>(() => new AmbientDbContextLocator());
            ScanDbContextsForEntities();
        }

        private void ScanDbContextsForEntities()
        {
            if (!_entitiesAlreadyScanned)
            {
                var types = new List<Type>();
                var entitiesTypes = new List<Tuple<Type, PropertyInfo>>();
                AppDomain.CurrentDomain.GetAssemblies().ForEach(assembly => types.AddRange(assembly.GetTypes()));
                var appBaseName = GetType().Namespace.Substring(0, GetType().Namespace.IndexOf('.'));
                var contextsTypes = types.Where(type => type.IsClass && type.IsSubclassOf(typeof(DbContext)) && !type.IsAbstract && type.Namespace.Contains(appBaseName)).ToList();

                contextsTypes.ForEach(contextType => contextType.GetProperties().ForEach(info => entitiesTypes.Add(new Tuple<Type, PropertyInfo>(info.GetGetMethod().ReturnType, info))));

                //contextsTypes
                //    .ForEach(contextType => contextType
                //        .GetProperties()
                //        .ToList()
                //        .ForEach(info => _entitiesContextRegistry.Add(info.GetGetMethod().ReturnType.GetGenericBaseType().FullName, () => info.DeclaringType)));


                entitiesTypes
                    .Select(tuple => new Tuple<Type, PropertyInfo>(tuple.Item1.GetGenericBaseType(), tuple.Item2))
                    .ToList()
                    .Where(tuple => tuple.Item1 != null)
                    .ToList()
                    .ForEach(tuple => EntitiesContextRegistry.Add(tuple.Item1.FullName, () => tuple.Item2.DeclaringType));

                _entitiesAlreadyScanned = true; 
            }
        }

        #endregion
    }
}
