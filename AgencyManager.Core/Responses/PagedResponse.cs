using System.Text.Json.Serialization;

namespace AgencyManager.Core.Responses
{    
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(
            TData? data,
            int totalCount,
            int currentPage = 1,
            int pageSize = Configuration.DefaultPageSize)
            : base(data)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Data = data;
        }

        public PagedResponse(
            TData? data,
            int code = Configuration.DefaultStatusCode,
            string? message = null)
            : base(data, code, message)
        {

        }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
        public int TotalCount { get; set; }
    }
}