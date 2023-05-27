using InfoKiosk.Modules.Home.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace InfoKiosk.Modules.Home
{
    public class HomeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //throw new NotImplementedException();
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", typeof(HomeView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //throw new NotImplementedException();
        }
    }
}