using Prism.Ioc;
using Prism.Regions;
using Prism.Modularity;
using InfoKiosk.Modules.Navigation.Services;
using InfoKiosk.Modules.Navigation.Views;
using InfoKiosk.Modules.Navigation.Services.Implementations;

namespace InfoKiosk.Modules.Navigation
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("NavigationRegion", typeof(NavigationWithBarView));

            var navigationWindowRunner = containerProvider.Resolve<INavigationWindowRunner>();
            navigationWindowRunner.Run();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRegistryRepository, RegistryRepository>();
            containerRegistry.Register<INavigator, Navigator>();
            containerRegistry.Register<INavigationRegistry, NavigationRegistry>();
            containerRegistry.Register<INavigationWindowRunner, NavigationWindowRunner>();
        }
    }
}