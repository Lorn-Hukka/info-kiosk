using System.Windows;
using InfoKiosk.Modules.Navigation.ViewModel;

namespace InfoKiosk.Modules.Navigation.Windows
{
    /// <summary>
    /// Interaction logic for NavigationWindow.xaml
    /// </summary>
    public partial class NavigationWindow : Window
    {
        public NavigationWindow(NavigationWindowViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
