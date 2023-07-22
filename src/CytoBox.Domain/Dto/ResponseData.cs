namespace CytoBox.Domain.Dto
{
    public class ResponseData<T>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
