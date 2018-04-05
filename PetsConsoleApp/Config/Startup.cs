using Autofac;
using System.Reflection;

namespace PetsConsoleApp.Config
{
    /// <summary>
    /// Startup class is used by Program.Main() to initialise application level configuration.
    /// </summary>
    public static class Startup
    {
        
        /// <summary>
        /// This method is responsible to initalise Container property and register all interfaces in assembly as dependency.
        /// </summary>
        public static IContainer ContainerConfig()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            return builder.Build();
        }
       

    }
}
