using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CytoBox.EntityFrameWorkCore.EntityFrameworkCore
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = args.Any() ? BuildConfiguration(true) : BuildConfiguration();

            var Enable = configuration["ConnectionStrings:Enable"];

            var builder = new DbContextOptionsBuilder<AppDbContext>();

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
                case "PostgreSQL":
                    builder.UseNpgsql(configuration.GetConnectionString(Enable));
                    break;
            }

            return new AppDbContext(builder.Options);
        }

        /// <summary>
        /// 获取文件位置
        /// </summary>
        /// <param name="runtime">是否运行时</param>
        /// <returns></returns>
        private static IConfigurationRoot BuildConfiguration(bool runtime = false)
        {
            var builder = new ConfigurationBuilder();

            if (runtime)
                builder.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
            else
                builder.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CytoBox.DbMigrator/"));

            return builder.AddJsonFile("appsettings.json", optional: false)
                .Build();
        }
    }
}
