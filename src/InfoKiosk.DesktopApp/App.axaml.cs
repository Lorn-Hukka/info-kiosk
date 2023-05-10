using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using InfoKiosk.Client.PocketBase;
using InfoKiosk.Desktop.ImagePresentation;
using Microsoft.Extensions.Configuration;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;

namespace InfoKiosk.DesktopApp
{
    public partial class App : PrismApplication
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            base.Initialize();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var configuration = BuildConfiguration();
            containerRegistry.RegisterInstance(configuration);
        }

        protected override AvaloniaObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<PocketBaseClientModule>();
            moduleCatalog.AddModule<ImagePresentationModule>();
        }

        private IConfiguration BuildConfiguration()
        {
            const string configurationFileName = "appsettings.json";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configurationFileName, false, true);

            return builder.Build();
        }
    }
}