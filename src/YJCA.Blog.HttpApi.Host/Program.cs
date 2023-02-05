using IGeekFan.AspNetCore.Knife4jUI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

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
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "YJCA.Blog API", Version = "V1" });
    s.AddServer(new OpenApiServer()
    {
        Url = "",
        Description = ""
    });
    s.CustomOperationIds(apiDesc =>
    {
        var controllerAction = apiDesc.ActionDescriptor as ControllerActionDescriptor;
        return $"{controllerAction.ControllerName}-{controllerAction.ActionName}";
    });
    s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SwaggerDemo.xml"), true);
});

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
        s.RoutePrefix = string.Empty; // serve the UI at root
        s.SwaggerEndpoint("/v1/api-docs", "V1 Docs");
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
