using System.Windows;

namespace InfoKiosk.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            Wpf.Ui.Appearance.Theme.Apply(
              Wpf.Ui.Appearance.ThemeType.Light,     // Theme type
              Wpf.Ui.Appearance.BackgroundType.Acrylic, // Background type
              true                                   // Whether to change accents automatically
            );
            InitializeComponent();
        }
    }
}
