namespace CytoBox.Core.HttpTool
{
    /// <summary>
    /// http请求封装
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// 发起请求
        /// </summary>
        /// <typeparam name="TResult">泛型类型</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="content">请求体</param>
        /// <param name="method">http 方法</param>
        /// <param name="token">签名</param>
        /// <returns></returns>
        Task<TResult> HttpSendAsync<TResult>(string url, object? content = default, HttpMethod? method = default, string token = "") where TResult : class, new();
    }
}
