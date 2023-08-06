using CytoBox.HttpApi.Host.Commons.Filters;
using CytoBox.ServiceRegistration.AutoServiceRegistration;
using CytoBox.ServiceRegistration.TieredServiceRegistration;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CytoBox.HttpApi.Host.ServiceRegister
{
    internal class ModuleInit : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            // Filter
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add<FunActionFilter>();

                //options.Filters.Add<RateLimitActionFilter>(); // 限流器
            });
            string assemblyPrefix = Assembly.GetExecutingAssembly().GetName().Name!.Split('.').FirstOrDefault()!;
            services.AddAutoDi(assemblyPrefix);
        }
    }
}
