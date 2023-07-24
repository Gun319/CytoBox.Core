using System;

namespace Cytobox.ServiceRegistration.AutoServiceRegistration
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AutoInjectAttribute : Attribute
    {
        public Type Type { get; set; }

        public InjectType InjectType { get; set; }

        public AutoInjectAttribute(Type interfaceType, InjectType injectType)
        {
            Type = interfaceType;
            InjectType = injectType;
        }
    }
}