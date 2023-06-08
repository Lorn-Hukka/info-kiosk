using Prism.Ioc;
using Prism.Modularity;
using InfoKiosk.Modules.Home.Views;
using InfoKiosk.Modules.Home.ViewModels;
using InfoKiosk.Modules.Navigation.Services;

namespace InfoKiosk.Modules.Home
{
    public class HomeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var navigationRegistry = containerProvider.Resolve<INavigationRegistry>();
            navigationRegistry.RegisterHome<HomeView, HomeNavigationView>();
            var navigator = containerProvider.Resolve<INavigator>();
            navigator.NavigateToHome();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<HomeNavigationViewModel>();
        }
    }
}