using Microsoft.EntityFrameworkCore;
using YJCA.Blog.Domain.Entity;

namespace YJCA.Blog.EntityFrameWorkCore.EntityFrameworkCore
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        /* Add DbSet properties for your Entities here. */
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BlogConsts.DbTablePrefix + "YourEntities", BlogConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
            builder.Entity<UserInfo>().HasNoKey().ToTable("T_UserInfo");

            builder.Entity<Role>().HasNoKey().ToTable("T_Role");

            builder.Entity<UserRole>().HasNoKey().ToTable("T_UserRole");
        }
    }
}
