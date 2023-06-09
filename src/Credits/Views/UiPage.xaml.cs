using InfoKiosk.Modules.Credits.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfoKiosk.Modules.Credits.Views
{
    /// <summary>
    /// Interaction logic for UiPage.xaml
    /// </summary>
    public partial class UiPage
    {
        public UiPage()
        {
            InitializeComponent();
            DataContext = new CreditsViewModel();
        }
    }
}
