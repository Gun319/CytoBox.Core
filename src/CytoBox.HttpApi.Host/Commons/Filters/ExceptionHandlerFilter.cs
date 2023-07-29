using CytoBox.Core.HttpTool;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace CytoBox.HttpApi.Host.Commons.Filters
{
    /// <summary>
    /// 异常拦截
    /// </summary>
    public class ExceptionHandlerFilter
    {
        /// <summary>
        /// 中心化异常处理
        /// </summary>
        /// <param name="app"></param>
        public static void ExceptionHandler(WebApplication app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = HttpContentType.APPLICATION_JSON;

                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    if (exception is not null)
                    {
                        if (!app.Environment.IsDevelopment())
                        {
                            var error = new
                            {
                                exception.Error.Message
                            };
                            string errorOjb = JsonSerializer.Serialize(error);

                            await context.Response.WriteAsync(errorOjb).ConfigureAwait(false);
                        }
                        else
                        {
                            var error = new
                            {
                                Code = HttpStatusCode.InternalServerError,
                                exception.Error.Message
                            };
                            string errorOjb = JsonSerializer.Serialize(error);

                            await context.Response.WriteAsync(errorOjb).ConfigureAwait(false);
                        }
                    }
                });
            });
        }
    }
}
