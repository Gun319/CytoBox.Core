using CytoBox.Core.Enum;
using CytoBox.ServiceRegistration.TieredServiceRegistration;
using IGeekFan.AspNetCore.Knife4jUI;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 注册 Swagger
builder.Services.AddSwaggerGen(s =>
{
    typeof(OpenApiGroup).GetEnumNames().ToList().ForEach(version =>
    {
        s.SwaggerDoc(version, new OpenApiInfo { Title = $"{version} API", Version = version });

        s.AddServer(new OpenApiServer()
        {
            Url = $" ",
            Description = "vvv"
        });

        s.CustomOperationIds(apiDesc =>
        {
            var controllerAction = apiDesc.ActionDescriptor as ControllerActionDescriptor;
            return $"{controllerAction?.ControllerName}-{controllerAction?.ActionName}";
        });
    });

    s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SwaggerDemo.xml"), true);
});

// 分层服务注入
string assemblyPrefix = Assembly.GetExecutingAssembly().GetName().Name!.Split('.').FirstOrDefault()!;
builder.Services.RunModuleInitializers(ReflectionScheduler.GetAllReferencedAssemblies(assemblyPrefix));

// 是否启用跨域
if (config.GetValue<bool>("IsEnableCors"))
{
    builder.Services.AddCors(option =>
    {
        option.AddPolicy("cors", builder =>
        {
            builder.AllowAnyMethod().SetIsOriginAllowed(_ => true).AllowAnyHeader().AllowCredentials();
        });
    });
}

var app = builder.Build();
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseKnife4UI(s =>
    {
        s.RoutePrefix = ""; // serve the UI at root

        typeof(OpenApiGroup).GetEnumNames().ToList().ForEach(version =>
        {
            s.SwaggerEndpoint($"/{version}/api-docs", $"{version} Docs");
        });

        s.DefaultModelExpandDepth(-1); // 隐藏 API 中定义的 model
    });
}

if (config.GetValue<bool>("IsEnableCors"))
{
    app.UseCors("cors");
}

// 路由中间件一定要添加
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapSwagger("{documentName}/api-docs");
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();
