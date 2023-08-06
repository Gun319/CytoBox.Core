using CytoBox.Core.Enums;
using CytoBox.ServiceRegistration.TieredServiceRegistration;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CytoBox.HttpApi.Host.ServiceRegister
{
    /// <summary>
    /// 注册服务
    /// </summary>
    public static class RegisterServiceExtensions
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder">WebApplicationBuilder</param>
        /// <param name="config">Configuration</param>
        /// <returns></returns>
        public static WebApplicationBuilder RegisterService(this WebApplicationBuilder builder, IConfigurationRoot config)
        {
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

            return builder;
        }
    }
}
