using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Roz.Data;
using Roz.Data.EntityFramework;
using Roz.WebApp;
using Roz.WebApp.Migrations.Application;
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
                new MigrateDatabaseToLatestVersion<ApplicationDbContext, ConfigurationApplication>());

            ((IEFDataEngine)DataEngine.GetEngine(typeof(EFDataEngine).FullName)).RegisterInitializer(
                new MigrateDatabaseToLatestVersion<BooksDbContext, ConfigurationBooks>());

        }
    }
}