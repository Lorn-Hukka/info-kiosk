using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using Avalonia.Win32;
using InfoKiosk.ViewModels;
using InfoKiosk.Views;
using System.Linq;

namespace InfoKiosk
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
                var window = new MainWindow();
                window.DataContext = new MainWindowViewModel();
                Screen? smallerScreen = GetSmallerScreen();
                window.Position = new PixelPoint(smallerScreen.Bounds.X, 0);
                window.Show();
            }

            base.OnFrameworkInitializationCompleted();
        }

        private static Screen? GetSmallerScreen()
        {
            var screenImpl = new ScreenImpl();
            var allScreens = screenImpl.AllScreens;
            int lowestWidth = allScreens.Min(scr => scr.Bounds.Width);
            var smallerScreen = allScreens.Where(scr => scr.Bounds.Width == lowestWidth).FirstOrDefault();
            return smallerScreen;
        }
    }
}