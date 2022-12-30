using YJCA.Blog.Domain.Entity;

namespace YJCA.Blog.EntityFrameWorkCore.EntityFrameworkCore
{
    public static class DbInitializer
    {
        public static void Initialize(BlogDbContext context)
        {
            if (context.Roles.Any()) return;

            var roles = new Role[]
            {
                new Role(),
                new Role()
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    }
}
