using CytoBox.Core.HttpTool;
using CytoBox.ServiceRegistration.TieredServiceRegistration;
using Microsoft.Extensions.DependencyInjection;

namespace CytoBox.Core
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
