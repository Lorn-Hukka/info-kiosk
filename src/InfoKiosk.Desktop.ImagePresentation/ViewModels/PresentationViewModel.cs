using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using InfoKiosk.Desktop.ImagePresentation.Services;
using Prism.Commands;
using Prism.Regions;
using ReactiveUI;

namespace InfoKiosk.Desktop.ImagePresentation.ViewModels
{
    internal class PresentationViewModel
    {
        private readonly PresentationController _presentationController;

        public PresentationViewModel(PresentationController presentationController)
        {
            _presentationController = presentationController;
            NextCommand = new AsyncRelayCommand(Next);
            PreviousCommand = new AsyncRelayCommand(Previous);
        }

        public ICommand NextCommand { get; }
        public ICommand PreviousCommand { get; }

        private async Task Next()
        {
            await _presentationController.Next(NavigationCallback);
        }

        private async Task Previous()
        {
            await _presentationController.Previous(NavigationCallback);
        }

        private void NavigationCallback(NavigationResult result)
        {

        }
    }
}
