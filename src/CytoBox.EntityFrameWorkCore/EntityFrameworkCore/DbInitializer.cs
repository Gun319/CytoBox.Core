using CytoBox.Domain.Entity;

namespace CytoBox.EntityFrameWorkCore.EntityFrameworkCore
{
    public static class DbInitializer
    {
        public static async Task<string> Initialize(BlogDbContext context)
        {
            try
            {
                if (context.Roles.Any()) return "";
                var roles = new Role[]
                {
                    new Role{RoleId = 1, RoleName = "Admin", Description = "管理员"},
                    new Role{RoleId = 2, RoleName = "Ordinary", Description = "普通用户"},
                };
                await context.Roles.AddRangeAsync(roles);


                if (context.UserInfos.Any()) return "";
                var userInfo = new UserInfo[]
                {
                    new UserInfo{UserId = 20230101, LoginName = "Admin", RealName = "管理员", Name = "Admin", LoginPWD = "123456" }
                };
                await context.UserInfos.AddRangeAsync(userInfo);


                if (context.UserRoles.Any()) return "";
                var userRoles = new UserRole[]
                {
                    new UserRole{UserId = 20230101, RoleId = 1}
                };
                await context.UserRoles.AddRangeAsync(userRoles);

                await context.SaveChangesAsync();
                return "SaveChange Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
                throw;
            }
        }
    }
}
