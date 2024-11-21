using System.Text.Json.Serialization;

namespace AgencyManager.Core.Responses
{    
    public class Response<TData>
    {       
        [JsonConstructor]
        public Response() => Code = Configuration.DefaultStatusCode;
        public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
        {
            Code = code;
            Data = data;
            Message = message;
        }

        [JsonPropertyName("_code")]
        public int Code { get; private set; }

        [JsonPropertyName("data")]
        public TData? Data { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => Code is >= -200 and <= 299;
    }
}