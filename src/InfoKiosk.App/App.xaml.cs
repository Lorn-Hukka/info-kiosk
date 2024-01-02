﻿using Prism.Ioc;
using Prism.DryIoc;
using System.Windows;
using Prism.Modularity;
using InfoKiosk.Modules.Navigation;
using InfoKiosk.Modules.Survey;
using InfoKiosk.Modules.Survey.Views;

namespace InfoKiosk.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<PrismApplication>(this);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            
            moduleCatalog.AddModule<SurveyModule>();
            moduleCatalog.AddModule<NavigationModule>();
            
        }
    }
}
