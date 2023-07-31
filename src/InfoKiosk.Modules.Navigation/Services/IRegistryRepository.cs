using System.Windows.Controls;

namespace InfoKiosk.Modules.Navigation.Services
{
    internal interface IRegistryRepository
    {
        Type GetNavigation<TView>()
            where TView : UserControl;
        public void Add<TView, TNavigationView>()
            where TView : UserControl
            where TNavigationView : UserControl;

        public (Type viewType, Type navigationType) GetHome();
        public void SetHome<TView, TNavigationView>()
            where TView : UserControl
            where TNavigationView : UserControl;
    }
}
