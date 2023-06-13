using Prism.Ioc;
using Prism.Regions;
using Prism.Modularity;
using InfoKiosk.Modules.InfoMain.Views;

namespace InfoKiosk.Modules.InfoMain
{
    public class InfoMainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("MainRegion", typeof(InfoMainView));
            //regionManager.RegisterViewWithRegion("MainRegion", typeof(InfoGeneralView));
            regionManager.RegisterViewWithRegion("MainRegion", typeof(InfoWBMiIView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}