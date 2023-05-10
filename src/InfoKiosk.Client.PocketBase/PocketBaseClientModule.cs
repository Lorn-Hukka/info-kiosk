using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Modularity;

namespace InfoKiosk.Client.PocketBase
{
    public class PocketBaseClientModule: IModule
    {
        private readonly IConfiguration _configuration;

        public PocketBaseClientModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var pocketBaseConfig = _configuration
                .GetSection("PocketBase")
                .Get<PocketBaseConfig > ();
            
            containerRegistry.Register<IClient>(
                x =>
                {
                    var pocketBase = new pocketbase_csharp_sdk.PocketBase(pocketBaseConfig.HostURL);
                    var user = pocketBase.Admin.AuthenticateWithPassword(pocketBaseConfig.User, pocketBaseConfig.Password);
                    return new PocketBaseClient(pocketBase);
                });
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
    }
}
