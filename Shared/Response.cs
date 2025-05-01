namespace TheBridge.Shared
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Response() { }

        public Response(T data, string message = "", bool success = true)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static Response<T> SuccessResponse(T data, string message = "") =>
            new(data, message, true);

        public static Response<T> FailResponse(string message) =>
            new(default, message, false);
    }
}
