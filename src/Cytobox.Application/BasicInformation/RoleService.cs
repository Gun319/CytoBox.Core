using CytoBox.Application.Contracts.BasicInformation;
using CytoBox.Core.Consts;
using CytoBox.Core.Extensions;
using CytoBox.Core.Result;
using CytoBox.EntityFrameWorkCore.EntityFrameworkCore;
using CytoBox.ServiceRegistration.AutoServiceRegistration;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Cytobox.Application.BasicInformation
{
    /// <summary>
    /// 角色实现
    /// </summary>
    [AutoInject(typeof(IRoleService), InjectType.Scope)]
    public class RoleService : IRoleService
    {
        private readonly IDbContextFactory _context;

        public RoleService(IDbContextFactory context)
        {
            _context = context;
        }

        public async Task<ServiceResult> CreateRoleAsync(CreateRoleDto input)
        {
            var result = new ServiceResult();
            var context = _context.WriteContext();
            try
            {
                var role = context.Roles.Where(r => r.RoleName == input.RoleName);

                // 判断当前角色是否存在
                if (await role.AnyAsync())
                {
                    result.IsFailed($"{input.RoleName}角色已存在");
                    return result;
                }

                // 新增角色
                var roleDto = new Role
                {
                    RoleName = input.RoleName
                };

                await context.AddAsync(roleDto);
                await context.SaveChangesAsync();
                result.IsSuccess(ResponseText.INSERT_SUCCESS);
            }
            catch (Exception ex)
            {
                result.IsFailed(message: ex.ToString());
            }
            return result;
        }

        public async Task<ServiceResult> DeleteRoleAsync(int input)
        {
            var result = new ServiceResult();
            var context = _context.WriteContext();
            var role = context.Roles.Where(r => r.RoleId == input);

            // 判断当前角色是否存在
            if (await role.AnyAsync())
            {
                result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("Id", input));
                return result;
            }
            // 删除角色
            context.Remove(input);
            await context.SaveChangesAsync();
            result.IsSuccess(ResponseText.DELETE_SUCCESS);
            return result;
        }

        public async Task<ServiceResult<List<QueryRoleDto>>> QueryRoleListAsync()
        {
            var result = new ServiceResult<List<QueryRoleDto>>();
            var context = _context.ReadContext();
            var roleList = await context.Roles.Select(r => new QueryRoleDto
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName
            }).ToListAsync();

            result.IsSuccess(roleList);
            return result;
        }

        public async Task<ServiceResult> UpdateRoleAsync([NotNull] UpdateRoleDto input)
        {
            var result = new ServiceResult();
            var context = _context.WriteContext();
            var role = await context.Roles.Where(r => r.RoleName == input.RoleName).FirstOrDefaultAsync();

            if (role is null)
            {
                result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("RoleName", input.RoleName));
                return result;
            }
            role.RoleName = input.RoleName;

            context.Update(role);
            await context.SaveChangesAsync();

            result.IsSuccess(ResponseText.UPDATE_SUCCESS);
            return result;
        }
    }
}
