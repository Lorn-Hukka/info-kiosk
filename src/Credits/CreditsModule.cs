using InfoKiosk.Modules.Credits.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace InfoKiosk.Modules.Credits
{
	public class CreditsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion("MainRegion", typeof(CreditsView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
		}
	}
}