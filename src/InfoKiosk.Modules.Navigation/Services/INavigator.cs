using System.Windows.Controls;

namespace InfoKiosk.Modules.Navigation.Services
{
    public interface INavigator
    {
        void Navigate<TView>() where TView: UserControl;

        void NavigateToHome();

        void NavigateToPrevious();
    }
}
