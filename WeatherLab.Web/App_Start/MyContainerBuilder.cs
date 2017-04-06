using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace WeatherLab.Web
{
    public static class MyContainerBuilder
    {
        public static IWindsorContainer Build(HttpConfiguration config)
        {
            // Install-Package Castle.Windsor
            // Install-Package Castle.LoggingFacility
            var container = new WindsorContainer();;
       
            // register the common assembly
            RegisterAllDefaultInterfaces(container, "WeatherLab.Model");
      
            // register API
            container.Register(Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient());
            config.Services.Replace(typeof(IHttpControllerActivator), new WindsorControllerActivator(container));
      
            container.Install(FromAssembly.This());
            
            return container;
        }

       private static void RegisterAllDefaultInterfaces(IWindsorContainer container, string assembly)
        {
            container.Register(Classes
                .FromAssembly(GetAssembly(assembly))
                .BasedOn<object>()
                .WithService.AllInterfaces()
                .LifestyleTransient());
        }
    
        private static Assembly GetAssembly(string name)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Single(a => a.Name == name);
            return Assembly.Load(assemblyName);
        }
    }
}