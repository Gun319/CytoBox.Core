using System;

namespace CytoBox.Domain.Entity
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role
    {
        public Role()
        {
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;
            IsDeleted = false;
        }

        public Role(string name)
        {
            RoleName = name;
            Description = "";
            Enabled = true;
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 自定义权限的部门ids
        /// </summary>
        public string? Dids { get; set; }

        /// <summary>
        /// 权限范围
        /// <para>
        /// -1 无任何权限；1 自定义权限；2 本部门；3 本部门及以下；4 仅自己；9 全部；
        /// </para>
        /// </summary>
        public int AuthorityScope { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 创建ID
        /// </summary>
        public long? CreateId { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string? CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改ID
        /// </summary>
        public long? ModifyId { get; set; }

        /// <summary>
        /// 修改者
        /// </summary>
        public string? ModifyBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; } = DateTime.Now;
    }
}
