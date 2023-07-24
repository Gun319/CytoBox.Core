using CytoBox.Core.Result;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Cytobox.Core.HttpTool
{
    public class HttpClientProvider : IHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HttpClientProvider> _logger;
        public HttpClientProvider(IHttpClientFactory httpClientFactory, ILogger<HttpClientProvider> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<TResult> HttpSendAsync<TResult>(string url, object? content = null, HttpMethod? method = default, string token = "") where TResult : class, new()
        {
            using HttpClient client = _httpClientFactory.CreateClient();

            method ??= HttpMethod.Post;
            using var request = new HttpRequestMessage { RequestUri = new Uri(url, UriKind.RelativeOrAbsolute), Method = method };

            if (method != HttpMethod.Get)
                request.Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");

            request.Headers.Add("Accept", "application/json");

            if (!string.IsNullOrWhiteSpace(token))
                request.Headers.Add("Authorization-Token", token);

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await client.SendAsync(request).ConfigureAwait(false);
                string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonSerializer.Deserialize<TResult>(responseBody)!;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, message: ex.Message);
                return (TResult)ConverDefaultResponse<TResult>(ex.Message);
            }
        }

        private static object ConverDefaultResponse<TResult>(string msg) where TResult : class, new()
        {
#if DEBUG
            if (typeof(TResult) == typeof(CommonResponse<object>))
                return new CommonResponse<object> { Code = "-999", Message = msg };

            else if (typeof(TResult) == typeof(CommonResponse<string>))
                return new CommonResponse<string> { Code = "-999", Message = msg };

            else if (typeof(TResult) == typeof(CommonResponse<int>))
                return new CommonResponse<int> { Code = "-999", Message = msg };
#endif
            return Activator.CreateInstance(typeof(TResult))!;
        }
    }
}
