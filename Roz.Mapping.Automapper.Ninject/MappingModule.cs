using AutoMapper;
using Ninject.Modules;

namespace Roz.Mapping.Automapper.Ninject
{
    public class MappingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMappingProvider>().To<MappingProvider>();
            Bind<IMappingRegistry<IConfiguration, IMappingEngine>>().To(typeof(MappingProvider));
        }
    }
}
