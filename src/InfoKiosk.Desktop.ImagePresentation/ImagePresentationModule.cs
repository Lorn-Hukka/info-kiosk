using InfoKiosk.Desktop.ImagePresentation.Services;
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
            regionManager.RegisterViewWithRegion("MainRegion", typeof(PresentationView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ImagePresentationSlideView>();

            containerRegistry.Register<PresentationController>();
            containerRegistry.Register<SlideRepository>();
        }

    }
}