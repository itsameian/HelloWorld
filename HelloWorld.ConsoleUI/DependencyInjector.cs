using Unity;
using Unity.Lifetime;

namespace HelloWorld.ConsoleUI
{
    /// <summary>
    /// Static class for managing Unity Dependencies
    /// </summary>
    public static class DependencyInjector
    {
        private static readonly UnityContainer UnityContainer = new UnityContainer();
        /// <summary>
        /// Registers the unity container to inject Type T into Interface I
        /// </summary>
        /// <typeparam name="I">Interface name to be registered</typeparam>
        /// <typeparam name="T">Implementation to be registered, where T implements I</typeparam>
        public static void Register<I, T>() where T : I
        {
            UnityContainer.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }
        /// <summary>
        /// Resolves the dependencies of object type T
        /// </summary>
        /// <typeparam name="T">The object in which we wish to inject dependencies based on Unity IOC config</typeparam>
        /// <returns>Instantiated object of type T</returns>
        public static T Retrieve<T>()
        {
            return UnityContainer.Resolve<T>();
        }
    }
}
