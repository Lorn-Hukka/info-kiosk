using Prism.Ioc;
using Prism.Modularity;
using InfoKiosk.Modules.ModuleB.Views;
using InfoKiosk.Modules.Navigation.Services;

namespace InfoKiosk.Modules.ModuleB
{
    public class ModuleB : IModule
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