using HelloWorld.Interfaces;
using HelloWorld.Utilities;
using Unity;

namespace HelloWorld.ConsoleUI
{
    /// <summary>
    /// Bootstrapper class for teh HelloWorld.ConsoleUI
    /// </summary>
    class Bootstrap
    {
        private IUnityContainer container = new UnityContainer();
        public static void Init()
        {
            DependencyInjector.Register<ITextWriter, ConsoleWriter>();
            DependencyInjector.Register<IApiReader, ApiReader>();
            DependencyInjector.Register<IUnityContainer, UnityContainer>();
        }
    }
}
