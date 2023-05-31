using System.Windows.Controls;
using InfoKiosk.Modules.Credits.ViewModels;

namespace InfoKiosk.Modules.Credits.Views
{
	/// <summary>
	/// Interaction logic for CreditsView.xaml
	/// </summary>
	public partial class CreditsView : UserControl
	{
		public CreditsView(CreditsViewModel viewModel)
		{
			InitializeComponent();
            DataContext = viewModel;
        }
	}
}
