using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Roz.Data;
using Roz.Data.EntityFramework;
using Roz.I18N.EntityFramework.Entities;
using Roz.I18N.Providers.LocalizedText;

namespace Roz.I18N.EntityFramework
{
    public sealed class EFLocalizedTextProvider : LocalizedTextProviderBase, IEFLocalizedTextProvider
    {
        private static ConcurrentDictionary<string, ConcurrentDictionary<string, string>> _resourceCache;
        private readonly IRepository<long, Resource> _resourceRepository;
        private readonly object _cacheSyncRoot = new object();

        public EFLocalizedTextProvider(IRepository<long, Resource> resourceRepository)
        {
            _resourceRepository = resourceRepository;
            EnsureResourcesCache();
        }

        #region Overrides of LocalizedTextProviderBase

        /// <summary>
        /// Returns a resource object for the key and culture.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that contains the resource value for the <paramref name="resourceKey"/> and <paramref name="culture"/>.
        /// </returns>
        /// <param name="resourceKey">The key identifying a particular resource.</param><param name="culture">The culture identifying a localized value for the resource.</param>
        public override object GetObject(string resourceKey, CultureInfo culture)
        {
            culture = EnsureCulture(culture);

            ConcurrentDictionary<string, string> cultureSpecificValues;
            if (_resourceCache.TryGetValue(resourceKey, out cultureSpecificValues))
            {
                string resourceValue;
                if (cultureSpecificValues.TryGetValue(culture.Name, out resourceValue))
                {
                    return resourceValue;
                }
            }

            return null;
        }

        #endregion

        public void ReloadResourcesCache()
        {
            EnsureResourcesCache();
        }

        private void EnsureResourcesCache()
        {
            if (_resourceCache != null) return;

            lock (_cacheSyncRoot)
            {
                _resourceCache = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();
                _resourceCache = GetResources();
            }
        }

        private ConcurrentDictionary<string, ConcurrentDictionary<string, string>> GetResources()
        {
            var dbResources = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();
            
            var resources = new List<Resource>();
            using (DataEngine.GetEngine(typeof(EFDataEngine).FullName).DataContextScopeFactory.CreateReadOnly())
            {
                _resourceRepository
                        .All()
                        .Select(resource => resource)
                        .Distinct().ToList()
                        .ForEach(resources.Add);

                resources.ForEach(resource =>
                {
                    dbResources.TryAdd(resource.Key, new ConcurrentDictionary<string, string>());

                    var cultureSpecificValues = resource.Values.Select(value => value).ToList();
                    cultureSpecificValues.ForEach(value =>
                        dbResources[resource.Key].TryAdd(value.Culture.Name, value.Value));

                });
            }

            return dbResources;
        }
    }
}
