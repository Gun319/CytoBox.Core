using CytoBox.Core.Result;

namespace Cytobox.Application.Contracts.BasicInformation
{
    /// <summary>
    /// 角色
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> CreateRoleAsync(CreateRoleDto input);

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<List<QueryRoleDto>>> QueryRoleListAsync();

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> UpdateRoleAsync(UpdateRoleDto input);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> DeleteRoleAsync(int input);
    }
}