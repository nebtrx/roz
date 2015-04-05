using System;

namespace Roz.Mapping
{
    public interface IMappingProvider
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }

    public interface IMappingRegistry<out TMappingConfiguration, out TMappingEngine>: IMappingProvider
    {
        void RegisterMappings(Action<TMappingConfiguration, TMappingEngine> configurationAction);

        void Reset();
    }
}
