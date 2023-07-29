using Microsoft.AspNetCore.Mvc.Filters;

namespace CytoBox.HttpApi.Host.Commons.Filters
{
    /// <summary>
    /// 操作记录器
    /// </summary>
    public class FunActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<FunActionFilter> _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public FunActionFilter(ILogger<FunActionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 动作拦截
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext result = await next();

            var remoteIpAddress = context.HttpContext.Connection.RemoteIpAddress;
            int remotePort = context.HttpContext.Connection.RemotePort;
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            _logger.LogInformation($"Route：{remoteIpAddress}:{remotePort}/{controller}/{action}");

            if (result.Exception != null)
            {
                // 日志记录
                _logger.LogError(result.Exception, message: result.Exception.Message);
            }
        }
    }
}
