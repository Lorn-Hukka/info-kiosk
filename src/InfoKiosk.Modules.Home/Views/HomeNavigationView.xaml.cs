using System.Windows.Controls;
using InfoKiosk.Modules.Home.ViewModels;

namespace InfoKiosk.Modules.Home.Views
{
    /// <summary>
    /// Interaction logic for HomeNavigationView.xaml
    /// </summary>
    public partial class HomeNavigationView : UserControl
    {
        public HomeNavigationView(HomeNavigationViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
