using System.Windows.Controls;
using InfoKiosk.Modules.Navigation.ViewModel;

namespace InfoKiosk.Modules.Navigation.Views
{
    /// <summary>
    /// Interaction logic for NavigationWithBarView.xaml
    /// </summary>
    public partial class NavigationWithBarView : UserControl
    {
        public NavigationWithBarView(NavigationWithBarViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
