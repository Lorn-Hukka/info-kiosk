using InfoKiosk.Desktop.ImagePresentation.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace InfoKiosk.Desktop.ImagePresentation
{
    public class ImagePresentationModule: IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("Region1", typeof(PresentationView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

    }
}