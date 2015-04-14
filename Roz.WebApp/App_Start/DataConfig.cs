using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Roz.Data;
using Roz.Data.EntityFramework;
using Roz.Data.Model;
using Roz.I18N.EntityFramework;
using Roz.Identity;
using Roz.Identity.EntityFramework;
using Roz.WebApp;
using Roz.WebApp.Migrations.Books;
using Roz.WebApp.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DataConfig), "RegisterDataEngine")]
namespace Roz.WebApp
{
    public class DataConfig
    {
        public static void RegisterDataEngine()
        {
            DataEngine.RegisterDataEngine(typeof (EFDataEngine).FullName, () => new EFDataEngine());


            ((IEFDataEngine)DataEngine.GetEngine(typeof(EFDataEngine).FullName)).RegisterInitializer(
                new MigrateDatabaseToLatestVersion<IdentityDbContext, Roz.Identity.EntityFramework.Migrations.Configuration>());

            ((IEFDataEngine)DataEngine.GetEngine(typeof(EFDataEngine).FullName)).RegisterInitializer(
                new MigrateDatabaseToLatestVersion<BooksDbContext, ConfigurationBooks>());

            ((IEFDataEngine)DataEngine.GetEngine(typeof(EFDataEngine).FullName)).RegisterInitializer(
                new MigrateDatabaseToLatestVersion<DomainDbContext, Roz.Data.Model.Migrations.Configuration>());

            ((IEFDataEngine)DataEngine.GetEngine(typeof(EFDataEngine).FullName)).RegisterInitializer(
                new MigrateDatabaseToLatestVersion<I18NDbContext, Roz.I18N.EntityFramework.Migrations.Configuration>());

        }
    }
}