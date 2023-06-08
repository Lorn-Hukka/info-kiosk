using Prism.Ioc;
using Prism.Modularity;
using InfoKiosk.Modules.ModuleA.Views;
using InfoKiosk.Modules.Navigation.Services;

namespace InfoKiosk.Modules.ModuleA
{
    public class ModuleA : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var navigationRegistry = containerProvider.Resolve<INavigationRegistry>();
            navigationRegistry.RegisterView<TestView, TestNavigationView>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}