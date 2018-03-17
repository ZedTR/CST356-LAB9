using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using CST356_lab3.Data;
using CST356_lab3.repository;
using CST356_lab3.Services;
using CST356_lab3.Data.Entities;

namespace CST356_lab3.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<IClasses, ClassRepo>(Lifestyle.Scoped);
          
            container.Register<Iservice, Service>(Lifestyle.Scoped);
       
            container.Register<AppDb, AppDb>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}