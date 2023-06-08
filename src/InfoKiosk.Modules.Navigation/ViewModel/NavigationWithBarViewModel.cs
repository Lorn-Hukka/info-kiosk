using Prism.Regions;
using Prism.Commands;
using System.Windows.Input;
using InfoKiosk.Modules.Navigation.Services;

namespace InfoKiosk.Modules.Navigation.ViewModel
{
    public class NavigationWithBarViewModel
    {
        private readonly INavigator _navigator;

        public NavigationWithBarViewModel(IRegionManager regionManager, INavigator navigator)
        {
            _navigator = navigator;
            RegionManager = regionManager;
            NavigateToHomeCommand = new DelegateCommand(NavigateToHome);
            NavigateToPreviousCommand = new DelegateCommand(NavigateToPrevious);
        }
        public IRegionManager RegionManager { get; }
        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToPreviousCommand { get; }

        private void NavigateToHome()
        {
            _navigator.NavigateToHome();
        }
        private void NavigateToPrevious()
        {
            _navigator.NavigateToPrevious();
        }
    }
}
