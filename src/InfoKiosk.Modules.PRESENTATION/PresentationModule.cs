using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using InfoKiosk.Modules.PRESENTATION.Views;

namespace InfoKiosk.Modules.PRESENTATION
{
    public class PresentationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", typeof(Presentation));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}