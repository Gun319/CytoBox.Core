using CytoBox.Core.Enums;
using IGeekFan.AspNetCore.Knife4jUI;

namespace CytoBox.HttpApi.Host.ServiceRegister
{
    /// <summary>
    /// 中间件注册
    /// </summary>
    public static class RegisterMiddlewareExtensions
    {
        /// <summary>
        /// 注册中间件
        /// </summary>
        /// <param name="app">WebApplication</param>
        /// <param name="config">Configuration</param>
        /// <returns></returns>
        public static WebApplication RegisterMiddleware(this WebApplication app, IConfigurationRoot config)
        {
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

            return app;
        }
    }
}
