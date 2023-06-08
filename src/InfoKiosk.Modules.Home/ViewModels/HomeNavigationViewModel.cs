using Prism.Commands;
using System.Windows.Input;
using InfoKiosk.Modules.Navigation.Services;

namespace InfoKiosk.Modules.Home.ViewModels
{
    public class HomeNavigationViewModel
    {
        private readonly INavigator _navigator;
        public HomeNavigationViewModel(INavigator navigator)
        {
            _navigator = navigator;
            NavigateACommand = new DelegateCommand(NavigateA);
            NavigateBCommand = new DelegateCommand(NavigateB);
        }

        public ICommand NavigateACommand { get; }
        public ICommand NavigateBCommand { get; }

        private void NavigateA()
        {
            _navigator.Navigate<ModuleA.Views.TestView>();
        }
        private void NavigateB()
        {
            _navigator.Navigate<ModuleB.Views.TestView>();
        }
    }
}
