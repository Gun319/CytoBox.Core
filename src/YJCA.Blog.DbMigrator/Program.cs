// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using YJCA.Blog.EntityFrameWorkCore.EntityFrameworkCore;

BlogDbContextFactory dbContextFactory = new();

var dbContext = dbContextFactory.CreateDbContext();

var modelDiffer = dbContext.GetInfrastructure().GetService<IMigrationsModelDiffer>();

//modelDiffer.HasDifferences(,dbContext.Model)



var tfTrue = await dbContext.Database.EnsureCreatedAsync();

if (tfTrue)
{
    Console.WriteLine("数据库创建成功");
    DbInitializer.Initialize(dbContext);
    Console.WriteLine("种子数据写入完成");
}
else
    Console.WriteLine("数据库创建失败");

Console.ReadKey();
