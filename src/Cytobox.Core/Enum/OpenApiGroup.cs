using System.ComponentModel;

namespace Cytobox.Core.Enum
{
    public enum OpenApiGroup
    {
        [Description("用户接口")]
        User = 1,

        [Description("系统接口")]
        System = 2
    }
}
