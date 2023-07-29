using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace CytoBox.HttpApi.Host.Commons.Filters
{
    /// <summary>
    /// 请求限流器
    /// </summary>
    public class RateLimitActionFilter : IAsyncActionFilter
    {
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memoryCache"></param>
        public RateLimitActionFilter(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// 限流器
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string removeIP = context.HttpContext.Connection.RemoteIpAddress!.ToString();
            string cachKey = $"LastVisitTick_{removeIP}";
            long? lastTick = _memoryCache.Get<int?>(cachKey);

            if (lastTick is null || Environment.TickCount - lastTick > 1000)
            {
                _memoryCache.Set(cachKey, Environment.TickCount, TimeSpan.FromSeconds(5));
                return next();
            }

            context.Result = new ContentResult { StatusCode = StatusCodes.Status429TooManyRequests };
            return Task.CompletedTask;
        }
    }
}
