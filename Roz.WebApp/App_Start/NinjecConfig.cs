using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Roz.Data.EntityFramework;
using Roz.Infrastructure.Web.DI.Ninject;
using Roz.WebApp;
using Roz.WebApp.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjecConfig), "PreStart")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(NinjecConfig), "PostStart")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjecConfig), "Stop")]

namespace Roz.WebApp
{
    // TODO: MOVE to infrastructure
    public static class NinjecConfig 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Before Starting the application
        /// </summary>
        public static void PreStart() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// After Starting the application
        /// </summary>
        public static void PostStart()
        {
            //// start up NHibernate engine
            //dataEngine.Current.RegisterMappingAssemblies();
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Remove all validation providers before load the bindings
            ModelValidatorProviders.Providers.Clear();
            
            // load automatically the bindigs
            kernel.Load(AppDomain.CurrentDomain.GetAssemblies()
                .Except(new List<Assembly>() { Assembly.GetAssembly(typeof(WebCommonNinjectModule)) }));

            // set the dependency resolvers for MVC and Web API
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            DependencyResolver.SetResolver(new NinjectMvcDependencyResolver(kernel));
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectHttpDependencyResolver(kernel);

            // optional
            kernel.Bind(typeof (IUserStore<>)).To(typeof (UserStore<>));
            kernel.Bind(typeof(UserManager<>)).To(typeof(ApplicationUserManager));
            kernel.Bind<IAuthenticationManager>().ToMethod(context => HttpContext.Current.GetOwinContext().Authentication);
            kernel.Bind(typeof(SignInManager<,>)).To(typeof(ApplicationSignInManager));
        }
    }
}
