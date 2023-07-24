using Cytobox.EntityFrameWorkCore.EntityFrameworkCore;
using Cytobox.ServiceRegistration.TieredServiceRegistration;
using Microsoft.Extensions.DependencyInjection;

namespace Cytobox.EntityFrameWorkCore
{
    internal class ModuleInit : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<IDbContextFactory, DbContextFactory>();
        }
    }
}
