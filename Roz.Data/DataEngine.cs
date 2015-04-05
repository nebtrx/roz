using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Roz.Utilities;

namespace Roz.Data
{
    public abstract class DataEngine
    {
        #region [   Singleton & Lazy Loading    ]

        private static readonly Lazy<ConcurrentDictionary<string, DataEngineRegistration>> _dataEngineRegistry;

        public static IDataEngine Main
        {
            get
            {
                if (_dataEngineRegistry.Value.Count == 0)
                {
                    throw new NullReferenceException("No Data Engines has been registered");
                }
                return _dataEngineRegistry.Value.Values.OrderBy(registration => registration.Priority).First().Generator();
            }
        }

        public static DataEngineRegistration RegisterDataEngine(string name, Func<IDataEngine> buildFunction)
        {
            int priority = HigherPriority + 1 ;
            var registration = new DataEngineRegistration(name, priority, buildFunction);

            _dataEngineRegistry.Value.AddOrUpdate(registration.Name, s => registration, (s, tuple) => registration);
            return registration;
        }

        public static IDataEngine GetEngine(string name)
        {
            if (!_dataEngineRegistry.Value.ContainsKey(name))
                throw new ArgumentOutOfRangeException("Data Engine not registered.", (Exception) null);
            return _dataEngineRegistry.Value.GetOrAdd(name, (DataEngineRegistration) null).Generator();
        }

        static DataEngine()
        {
            _dataEngineRegistry = new Lazy<ConcurrentDictionary<string, DataEngineRegistration>>(() => new ConcurrentDictionary<string, DataEngineRegistration>());
        }

        /// <summary>
        /// Determine if type inherits from Entity and it's not the Entity class and it's not an interface
        /// </summary>
        public bool IsEntity(Type type)
        {
            return typeof(Entity).IsAssignableFrom(type) && typeof(Entity) != type && !type.IsInterface;
        }

        internal static int HigherPriority
        {
            get
            {
                return _dataEngineRegistry.Value.Count > 0
                    ? _dataEngineRegistry.Value.Values.Select(engineRegistration => engineRegistration.Priority).Max()
                    : 0;
            }
        }

        internal static int LowerPriority
        {
            get
            {
                return _dataEngineRegistry.Value.Count > 0
                    ? _dataEngineRegistry.Value.Values.Select(engineRegistration => engineRegistration.Priority).Min()
                    : 0;
            }
        }

        #endregion

        public class DataEngineRegistration
        {
            public string Name { get; set; }

            public int Priority { get; set; }

            public Func<IDataEngine> Generator { get; set; }

            public DataEngineRegistration(string name, int priority, Func<IDataEngine> generator)
            {
                Name = name;
                Priority = priority;
                Generator = generator;
            }
        }

        
    }

    public static class DataEngineRegistrationExtensions
    {
        public static void AsMainDataEngine(this DataEngine.DataEngineRegistration registration)
        {
            registration.Priority = DataEngine.LowerPriority - 1;
        }
    }

    
}