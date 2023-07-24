using System.Text.Json.Serialization;

namespace CytoBox.Core.Result
{
    /// <summary>
    /// 返回值包装器
    /// </summary>
    /// <typeparam name="T">泛型类型</typeparam>
    public class CommonResponse<T>
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("result")]
        public T? Result { get; set; }
    }
}
