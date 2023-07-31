using Prism.Regions;
using System.Windows.Controls;
using InfoKiosk.Modules.Navigation.Views;

namespace InfoKiosk.Modules.Navigation.Services.Implementations
{
    internal class Navigator: INavigator
    {
        private readonly IRegistryRepository _registry;
        private readonly IRegionManager _regionManager;

        public Navigator(IRegistryRepository registry, IRegionManager regionManager)
        {
            _registry = registry;
            _regionManager = regionManager;
        }

        public void Navigate<TView>() where TView : UserControl
        {
            var navigationType = _registry.GetNavigation<TView>();

            _regionManager.RequestNavigate("MainRegion", typeof(TView).FullName, x =>
            {

            });
            _regionManager.RequestNavigate("NavigationRegion", nameof(NavigationWithBarView), x =>
            {

            });
            _regionManager.RequestNavigate("NavigationContentRegion", navigationType.FullName, x =>
            {

            });
        }

        public void NavigateToHome()
        {
            var (homeType, navigationType) = _registry.GetHome();
            _regionManager.RequestNavigate("MainRegion", homeType.FullName, x =>
            {

            });
            _regionManager.RequestNavigate("NavigationRegion", navigationType.FullName, x =>
            {

            });
        }

        public void NavigateToPrevious()
        {
            // TODO Discuss the concepts
            throw new NotImplementedException();
        }
    }
}
