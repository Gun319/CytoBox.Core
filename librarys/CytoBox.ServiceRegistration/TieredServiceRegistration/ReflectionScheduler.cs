using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace CytoBox.ServiceRegistration.TieredServiceRegistration
{
    public class ReflectionScheduler
    {
        /// <summary>
        /// Determine if the file is an assembly 判断文件是否是程序集
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static bool IsManagedAssembly(string file)
        {
            using var fs = File.OpenRead(file);
            using PEReader peReader = new PEReader(fs);
            return peReader.HasMetadata && peReader.GetMetadataReader().IsAssembly;
        }

        /// <summary>
        /// Attempting to load assembly 尝试加载程序集
        /// </summary>
        /// <param name="assemblyPath">Assembly Path</param>
        /// <returns></returns>
        private static Assembly? TryLoadAssembly(string assemblyPath)
        {
            AssemblyName assemblyName = AssemblyName.GetAssemblyName(assemblyPath);
            Assembly? assembly = null;
            try
            {
                assembly = Assembly.Load(assemblyName);
            }
            catch (BadImageFormatException ex)
            {
                Debug.WriteLine(ex);
            }
            catch (FileLoadException ex)
            {
                Debug.WriteLine(ex);
            }

            if (assembly is null)
            {
                try
                {
                    assembly = Assembly.LoadFile(assemblyPath);
                }
                catch (BadImageFormatException ex)
                {
                    Debug.WriteLine(ex);
                }
                catch (FileLoadException ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return assembly;
        }

        /// <summary>
        /// Loop load all assemblies 循环加载所有程序集
        /// </summary>
        /// <param name="assemblyPrefix">Assembly Prefix</param>
        /// <returns></returns>
        public static IEnumerable<Assembly> GetAllReferencedAssemblies(string? assemblyPrefix = default)
        {
            var returnAssemblies = new HashSet<Assembly>(new AssemblyEquality());

            var assemblysInBaseDir = Directory.EnumerateFiles(AppContext.BaseDirectory, $"{assemblyPrefix}*.dll", new EnumerationOptions { RecurseSubdirectories = true });

            foreach (var assemblyPath in assemblysInBaseDir)
            {
                if (!IsManagedAssembly(assemblyPath)) continue;

                //AssemblyName asmName = AssemblyName.GetAssemblyName(assemblyPath);

                Assembly? assembly = TryLoadAssembly(assemblyPath);
                if (assembly == null) continue;

                returnAssemblies.Add(assembly);
            };

            return returnAssemblies.ToArray();
        }
    }

    class AssemblyEquality : EqualityComparer<Assembly>
    {
        public override bool Equals(Assembly? x, Assembly? y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return AssemblyName.ReferenceMatchesDefinition(x.GetName(), y.GetName());
        }

        public override int GetHashCode([DisallowNull] Assembly obj)
        {
            return obj.GetName().FullName.GetHashCode();
        }
    }
}
