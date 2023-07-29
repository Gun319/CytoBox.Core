using CytoBox.Core.HttpTool;
using Microsoft.AspNetCore.Mvc;

namespace CytoBox.HttpApi.Host.Commons
{
    /// <summary>
    /// 返回值包装类
    /// </summary>
    public class GetResult
    {
        /// <summary>
        /// ContentResult 返回值类型
        /// </summary>
        /// <param name="content"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static ContentResult GetResponseMessage(string content, string contentType = HttpContentType.TEXT_PLAIN)
        {
            return new ContentResult { Content = content, ContentType = contentType };
        }
    }
}
