using CytoBox.EntityFrameWorkCore.EntityFrameworkCore;
using CytoBox.ServiceRegistration.TieredServiceRegistration;
using Microsoft.Extensions.DependencyInjection;

namespace YJCA.IsolatingLayer.EntityFrameWorkCore
{
    internal class ModuleInit : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<IDbContextFactory, DbContextFactory>();
        }
    }
}
