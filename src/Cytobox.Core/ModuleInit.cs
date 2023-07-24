using Cytobox.Core.HttpTool;
using Cytobox.ServiceRegistration.TieredServiceRegistration;
using Microsoft.Extensions.DependencyInjection;

namespace Cytobox.Core
{
    internal class ModuleInit : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddMemoryCache();

            services.AddSingleton<IHttpClient, HttpClientProvider>();
        }
    }
}
