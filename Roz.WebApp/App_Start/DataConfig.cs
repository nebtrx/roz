using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Roz.Data;
using Roz.Data.EntityFramework;
using Roz.Identity;
using Roz.Identity.EntityFramework;
using Roz.Identity.EntityFramework.Migrations;
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
                new MigrateDatabaseToLatestVersion<IdentityDbContext, Configuration>());

            ((IEFDataEngine)DataEngine.GetEngine(typeof(EFDataEngine).FullName)).RegisterInitializer(
                new MigrateDatabaseToLatestVersion<BooksDbContext, ConfigurationBooks>());

        }
    }
}