// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using YJCA.Blog.EntityFrameWorkCore.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        BlogDbContextFactory dbContextFactory = new();

        var dbContext = dbContextFactory.CreateDbContext(new[] { "1" }).Database;

        if (dbContext.GetMigrations().Any())
            dbContext.Migrate();

        Console.WriteLine("数据库生成完成！");
        Console.ReadKey();
    }
}