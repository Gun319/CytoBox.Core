using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace YJCA.Blog.EntityFrameWorkCore.EntityFrameworkCore
{
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[]? args = null)
        {
            var configuration = BuildConfiguration();

            var Enable = configuration["ConnectionStrings:Enable"];

            var builder = new DbContextOptionsBuilder<BlogDbContext>();

            switch (Enable)
            {
                case "SqlServer":
                    builder.UseSqlServer(configuration.GetConnectionString(Enable));
                    break;
                case "Sqlite":
                    builder.UseSqlite(configuration.GetConnectionString(Enable));
                    break;
                case "MySql":
                    builder.UseMySql(configuration.GetConnectionString(Enable), MySqlServerVersion.LatestSupportedServerVersion);
                    break;
            }

            return new BlogDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../YJCA.Blog.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
