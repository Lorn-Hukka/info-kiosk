using System.Windows.Controls;

namespace InfoKiosk.Modules.Navigation.Services
{
    public interface INavigationRegistry
    {
        void RegisterView<TView, TNavigationView>()
            where TView : UserControl
            where TNavigationView : UserControl;

        void RegisterNavigation<TNavigationView>()
            where TNavigationView : UserControl;

        void RegisterHome<TView, TNavigationView>()
            where TView : UserControl
            where TNavigationView : UserControl;
    }
}
