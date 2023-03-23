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
                Screen? biggerScreen = GetBiggerScreen();
                Screen? smallerScreen = GetSmallerScreen();

                desktop.MainWindow = new MainWindow();
                desktop.MainWindow.DataContext = new MainWindowViewModel();
                desktop.MainWindow.Position = new PixelPoint(biggerScreen.Bounds.X, 0);

                var window = new InputWindow();
                window.DataContext = new InputWindowViewModel();
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
        private static Screen? GetBiggerScreen()
        {
            var screenImpl = new ScreenImpl();
            var allScreens = screenImpl.AllScreens;
            int highestWidth = allScreens.Max(scr => scr.Bounds.Width);
            var biggerScreen = allScreens.Where(scr => scr.Bounds.Width == highestWidth).FirstOrDefault();
            return biggerScreen;
        }
    }
}