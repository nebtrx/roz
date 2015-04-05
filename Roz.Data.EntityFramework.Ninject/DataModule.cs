using System.Data.Entity;
using Ninject.Modules;

namespace Roz.Data.EntityFramework.Ninject
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEFDataEngine>().ToMethod(context => (IEFDataEngine)DataEngine.GetEngine(typeof(EFDataEngine).FullName));
            Bind(typeof (IRepository<,>)).To(typeof (Repository<,>));
        }
    }
}
