using Prism.DryIoc;
using Prism.Regions;
using System.Windows;
using WpfScreenHelper;
using InfoKiosk.Modules.Navigation.Windows;
using InfoKiosk.Modules.Navigation.ViewModel;

namespace InfoKiosk.Modules.Navigation.Services.Implementations
{
    internal class NavigationWindowRunner: INavigationWindowRunner
    {
        private readonly IRegionManager _regionManager;
        private readonly PrismApplication _prismApplication;
        public NavigationWindowRunner(IRegionManager regionManager, PrismApplication prismApplication)
        {
            _regionManager = regionManager;
            _prismApplication = prismApplication;
        }

        public void Run()
        {
            var viewModel = new NavigationWindowViewModel(_regionManager);
            var navigationWindow = new NavigationWindow(viewModel);
            navigationWindow.Show();

#if DEBUG
            PlugInDebug(navigationWindow);
#else
            PlugInRelease(navigationWindow);
#endif
        }

        private void PlugInDebug(NavigationWindow navigationWindow)
        {
            const int mainWindowWidth = 1280;
            const int mainWindowHeight = 720;

            var mainWindow = _prismApplication.MainWindow;
            mainWindow.MaxWidth = mainWindowWidth;
            mainWindow.MinWidth = mainWindowWidth;
            mainWindow.Width = mainWindowWidth;
            mainWindow.MaxHeight = mainWindowHeight;
            mainWindow.MinHeight = mainWindowHeight;
            mainWindow.Height = mainWindowHeight;

            const int mainNavigationWidth = 800;
            const int mainNavigationHeight = 400;
            navigationWindow.MaxWidth = mainNavigationWidth;
            navigationWindow.MinWidth = mainNavigationWidth;
            navigationWindow.Width = mainNavigationWidth;
            navigationWindow.MaxHeight = mainNavigationHeight;
            navigationWindow.MinHeight = mainNavigationHeight;
            navigationWindow.Height = mainNavigationHeight;


            mainWindow.LocationChanged += (_, _) => SetNavigationPosition(mainWindow, navigationWindow);
            mainWindow.SizeChanged += (_, _) => SetNavigationPosition(mainWindow, navigationWindow);
            mainWindow.Loaded += (_, _) => SetNavigationPosition(mainWindow, navigationWindow);
            mainWindow.Closed += (_, _) => navigationWindow.Close();
            navigationWindow.Closed += (_, _) => mainWindow.Close();
        }

        private void SetNavigationPosition(Window mainWindow, Window navigationWindow)
        {
            var widthDiff = mainWindow.Width - navigationWindow.Width;
            navigationWindow.Left = mainWindow.Left + widthDiff / 2;
            navigationWindow.Top = mainWindow.Top + mainWindow.Height;
        }

        private void PlugInRelease(NavigationWindow navigationWindow)
        {
            var screens = Screen.AllScreens;
            if (screens.Count() < 2)
                throw new Exception("External monitor not connected");

            var mainWindow = _prismApplication.MainWindow;
            var primaryScreen = screens.SingleOrDefault(x => x.Primary);
            SetScreen(mainWindow, primaryScreen);
            mainWindow.Loaded += (sender, _) => Maximize(sender as Window);

            var navigationScreen = screens.LastOrDefault();
            SetScreen(navigationWindow, navigationScreen);
            navigationWindow.Loaded += (sender, _) => Maximize(sender as Window);
        }

        private void SetScreen(Window window, Screen screen)
        {
            window.WindowStartupLocation = WindowStartupLocation.Manual;
            window.Left = screen.Bounds.Left;
            window.Top = screen.Bounds.Top;
            window.Width = screen.Bounds.Width;
            window.Height = screen.Bounds.Height;
            window.WindowStyle = WindowStyle.None;
        }

        private void Maximize(Window window)
        {
            window.WindowState = WindowState.Maximized;
        }
    }
}
