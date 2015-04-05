using System;
using AutoMapper;

namespace Roz.Mapping.Automapper
{
    public class MappingProvider : IMappingRegistry<IConfiguration, IMappingEngine>
    {
        public void RegisterMappings(Action<IConfiguration, IMappingEngine> configurationAction)
        {
            configurationAction(Mapper.Configuration, Mapper.Engine);
        }

        public void Reset()
        {
            Mapper.Reset();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}