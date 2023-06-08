using Prism.Regions;

namespace InfoKiosk.Modules.Navigation.ViewModel
{
    public class NavigationWindowViewModel
    {
        public NavigationWindowViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        public IRegionManager RegionManager { get; }
    }
}
