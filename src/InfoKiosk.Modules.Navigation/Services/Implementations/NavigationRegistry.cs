using Prism.Regions;
using System.Windows.Controls;

namespace InfoKiosk.Modules.Navigation.Services.Implementations
{
    internal class NavigationRegistry: INavigationRegistry
    {
        private readonly IRegionManager _regionManager;
        private readonly IRegistryRepository _registryRepository;

        public NavigationRegistry(IRegionManager regionManager, IRegistryRepository registryRepository)
        {
            _regionManager = regionManager;
            _registryRepository = registryRepository;
        }

        public void RegisterView<TView, TNavigationView>() where TView : UserControl where TNavigationView : UserControl
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(TView));
            _regionManager.RegisterViewWithRegion("NavigationContentRegion", typeof(TNavigationView));
            _registryRepository.Add<TView, TNavigationView>();
        }

        public void RegisterNavigation<TNavigationView>() where TNavigationView : UserControl
        {
            _regionManager.RegisterViewWithRegion("NavigationContentRegion", typeof(TNavigationView));
        }

        public void RegisterHome<TView, TNavigationView>() where TView : UserControl where TNavigationView : UserControl
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(TView));
            _regionManager.RegisterViewWithRegion("NavigationRegion", typeof(TNavigationView));
            _registryRepository.SetHome<TView, TNavigationView>();
        }
    }
}
