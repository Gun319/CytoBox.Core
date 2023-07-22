using System;

namespace CytoBox.Domain.Entity
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        public UserInfo()
        {
        }

        public UserInfo(string loginName, string loginPWD)
        {
            LoginName = loginName;
            LoginPWD = loginPWD;
            RealName = LoginName;
            Status = 0;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            LastErrorTime = DateTime.Now;
            ErrorCount = 0;
            Name = "";
        }

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary> 
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary> 
        public string LoginPWD { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary> 
        public string RealName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary> 
        public string? Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 关键业务修改时间
        /// </summary>
        public DateTime CriticalModifyTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后异常时间 
        /// </summary>
        public DateTime LastErrorTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 错误次数 
        /// </summary>
        public int ErrorCount { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>        
        public int Sex { get; set; } = 0;

        /// <summary>
        /// 年龄
        /// </summary>        
        public int Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>        
        public DateTime Birth { get; set; } = DateTime.Now;

        /// <summary>
        /// 地址
        /// </summary>        
        public string? Address { get; set; }

        /// <summary>
        /// 获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary> 
        public int DepartmentId { get; set; } = -1;

        /// <summary>
        /// 部门
        /// </summary>
        public string? DepartmentName { get; set; }
    }
}
