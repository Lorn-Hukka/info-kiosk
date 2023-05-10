using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using InfoKiosk.Presentation.Views;

namespace InfoKiosk.Presentation
{
    public class PresentationModule: IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", typeof(PresentationView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}