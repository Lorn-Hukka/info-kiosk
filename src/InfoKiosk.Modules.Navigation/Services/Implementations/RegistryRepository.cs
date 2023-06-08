using System.Windows.Controls;

namespace InfoKiosk.Modules.Navigation.Services.Implementations
{
    internal class RegistryRepository: IRegistryRepository
    {
        private readonly Dictionary<Type, Type> _registeredViews = new();
        private Type _homeViewType;

        public Type GetNavigation<TView>() where TView : UserControl
        {
            return _registeredViews[typeof(TView)];
        }
        public void Add<TView, TNavigationView>() where TView : UserControl where TNavigationView : UserControl
        {
            _registeredViews.Add(typeof(TView), typeof(TNavigationView));
        }


        public (Type viewType, Type navigationType) GetHome()
        {
            if (_homeViewType is null)
                throw new InvalidOperationException("Home view is not set.");
            var navigation = _registeredViews[_homeViewType];
            return (_homeViewType, navigation);
        }
        public void SetHome<TView, TNavigationView>()
            where TView : UserControl
            where TNavigationView : UserControl
        {
            if (_homeViewType is not null)
                throw new InvalidOperationException("Home view is already set.");
            _homeViewType = typeof(TView);
            Add<TView, TNavigationView>();
        }
    }
}
