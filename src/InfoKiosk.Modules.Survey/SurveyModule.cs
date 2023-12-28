﻿using InfoKiosk.Modules.Survey.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace InfoKiosk.Modules.Survey
{
    public class SurveyModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", typeof(KeyBoardView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}