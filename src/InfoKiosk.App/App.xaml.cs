using System.Windows;
using InfoKiosk.Credits;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;

namespace InfoKiosk.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CreditsModule>();
        }
    }
}
