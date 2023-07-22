using Microsoft.Extensions.DependencyInjection;

namespace CytoBox.ServiceRegistration.TieredServiceRegistration
{
    /// <summary>
    /// Module Initializer
    /// </summary>
    public interface IModuleInitializer
    {
        /// <summary>
        /// Service Collection Initializer
        /// </summary>
        /// <param name="services"></param>
        public void Initialize(IServiceCollection services);
    }
}
