using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cytobox.ServiceRegistration.TieredServiceRegistration
{
    /// <summary>
    /// Module Initializer 模块初始化
    /// </summary>
    public static class ModuleInitializerExtensions
    {
        /// <summary>
        /// Module Initializer Method 模块初始化方法
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies">All Assemblies</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public static IServiceCollection RunModuleInitializers(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                var moduleInitializerTypes = assembly.GetTypes().Where(t => !t.IsAbstract && typeof(IModuleInitializer).IsAssignableFrom(t));

                foreach (var moduleInitializerType in moduleInitializerTypes)
                {
                    var initializer = (IModuleInitializer?)Activator.CreateInstance(moduleInitializerType)
                       ?? throw new ApplicationException($"Cannot create ${moduleInitializerType}");

                    initializer.Initialize(services);
                };
            }
            return services;
        }
    }
}
