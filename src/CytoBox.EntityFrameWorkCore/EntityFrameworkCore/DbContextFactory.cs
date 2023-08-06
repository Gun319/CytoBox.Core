using CytoBox.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace CytoBox.EntityFrameWorkCore.EntityFrameworkCore
{
    public class DbContextFactory : IDbContextFactory
    {
        [NotNull]
        private readonly IConfiguration? _configuration;
        private readonly string[]? ReadConn;

        public DbContextFactory([NotNull] IConfiguration configuration)
        {
            _configuration = configuration;

            ReadConn = _configuration.GetConnectionString("ReadConnStr")?.Split(',');
        }

        /// <summary>
        /// 读库
        /// <para>
        /// 从库
        /// </para>
        /// </summary>
        /// <returns></returns>
        public AppDbContext ReadContext() => CreateDbContext(WriteAndRead.Read);

        /// <summary>
        /// 写库
        /// <para>
        /// 主库
        /// </para>
        /// </summary>
        /// <returns></returns>
        public AppDbContext WriteContext() => CreateDbContext(WriteAndRead.Write);

        #region 私有

        /// <summary>
        /// 数据库提供程序
        /// </summary>
        /// <param name="writeAndRead"></param>
        /// <returns></returns>
        private AppDbContext CreateDbContext(WriteAndRead writeAndRead)
        {
            string? connStr = string.Empty;
            string? Enable = _configuration.GetConnectionString("Enable");

            switch (writeAndRead)
            {
                case WriteAndRead.Read:
                    connStr = GetReadConnStr();
                    break;
                case WriteAndRead.Write:
                    connStr = _configuration.GetConnectionString(Enable ?? string.Empty);
                    break;
            }

            var builder = new DbContextOptionsBuilder<AppDbContext>();

#if DEBUG
            builder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            builder.EnableSensitiveDataLogging();

            // 记录日志
            builder.LogTo(msg =>
            {
                // 调试-窗口消息
                System.Diagnostics.Debug.WriteLine(msg);
                // 输出-窗口消息
                Console.WriteLine(msg);
            });
#else
            builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
#endif

            switch (Enable)
            {
                case "SqlServer":
                    builder.UseSqlServer(connStr);
                    break;
                case "Sqlite":
                    builder.UseSqlite(connStr);
                    break;
                case "MySql":
                    builder.UseMySql(connStr, MySqlServerVersion.LatestSupportedServerVersion);
                    break;
                case "PostgreSQL":
                    builder.UseNpgsql(connStr);
                    break;
            }
            return new AppDbContext(builder.Options);
        }

        /// <summary>
        /// 从库连接策略
        /// </summary>
        /// <returns></returns>
        private string? GetReadConnStr()
        {
            string? QueryDbStrategy = _configuration.GetConnectionString("QueryDbStrategy");
            string? connStr = string.Empty;
            switch (QueryDbStrategy)
            {
                case "Random":
                    {
                        // to do 随机分配
                    }
                    break;
                case "Polling":
                    {
                        // to do 轮询
                    }
                    break;
                default:
                    connStr = ReadConn?.FirstOrDefault();
                    break;
            }
            return connStr;
        }

        #endregion
    }
}
