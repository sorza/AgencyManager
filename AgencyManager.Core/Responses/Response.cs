using System.Text.Json.Serialization;

namespace AgencyManager.Core.Responses
{
    public class Response<TData>
    {
        private readonly int _code;

        [JsonConstructor]
        public Response()
            => _code = Configuration.DefaultStatusCode;

        public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
        {
            _code = code;
            Data = data;
            Message = message;
        }
        public TData? Data { get; set; }
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => _code >= 200 && _code <= 299;
    }
}