using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CytoBox.ServiceRegistration.AutoServiceRegistration
{
    /// <summary>
    /// Auto DI
    /// </summary>
    public static class AutoInject
    {
        /// <summary>
        /// AddAutoDi
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="assemblyPrefix">Assembly Prefix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IServiceCollection AddAutoDi(this IServiceCollection serviceCollection, string? assemblyPrefix = default)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;

            var assemblies = Directory.GetFiles(path, $"{assemblyPrefix}*.dll").Select(Assembly.LoadFrom);

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(a => a.GetCustomAttribute<AutoInjectAttribute>() != null);

                if (!types.Any()) continue;

                foreach (var type in types)
                {
                    var attr = type.GetCustomAttribute<AutoInjectAttribute>();

                    switch (attr.InjectType)
                    {
                        case InjectType.Scope:
                            serviceCollection.AddScoped(attr.Type, type);
                            break;
                        case InjectType.Single:
                            serviceCollection.AddSingleton(attr.Type, type);
                            break;
                        case InjectType.Transient:
                            serviceCollection.AddTransient(attr.Type, type);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            return serviceCollection;
        }
    }
}
