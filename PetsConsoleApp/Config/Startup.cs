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
        /// IContainer is IOC container to manage all application level dependendies.
        /// This property is private. No direct access to Container property from outside.
        /// </summary>
        private static IContainer Container { get; set; }

        /// <summary>
        /// This method is responsible to initalise Container property and register all interfaces in assembly as dependency.
        /// </summary>
        public static void ConfigureApplication()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            Container = builder.Build();
        }

        /// <summary>
        /// This method is used to resolve dependencies. This is a generic method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

    }
}
