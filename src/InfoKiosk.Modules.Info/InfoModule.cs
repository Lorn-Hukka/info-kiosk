using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using InfoKiosk.Modules.Info.Views;

namespace InfoKiosk.Modules.Info
{
    public class InfoModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", typeof(InfoView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}