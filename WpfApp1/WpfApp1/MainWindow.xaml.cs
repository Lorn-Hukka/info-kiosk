


using System.Windows;
using System.Windows.Forms;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
                    

            InitializeComponent();

            var screens = Screen.AllScreens;
            var secondScreen = screens[1];
            SecondWindow secondWindow = new SecondWindow()
            {

                Height = secondScreen.WorkingArea.Height,
                Width = secondScreen.WorkingArea.Width,
                Left = secondScreen.WorkingArea.Left,
                Top = secondScreen.WorkingArea.Top,
                WindowStyle = WindowStyle.None,
                Topmost = true
            };
            
            
            secondWindow.Show();

        }
       


    }
}
