using System.Net;

namespace CleanArchitecture.Application.Wrappers
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(List<T> data)
        {
            Data = data;
        }
        public List<T> Data { get; set; }

        internal PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Data = data;
            CurrentPage = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            StatusCode = statusCode;
        }

        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new(true, data, null, count, page, pageSize, System.Net.HttpStatusCode.OK);
        }
        public static PaginatedResult<T> InternalServerError(List<T> data, int count, int page, int pageSize)
        {
            return new(false, new List<T>(), null, count, page, pageSize, System.Net.HttpStatusCode.InternalServerError);
        }
        public static PaginatedResult<T> Unauthorized(List<T> data, int count, int page, int pageSize)
        {
            return new(false, new List<T>(), null, count, page, pageSize, System.Net.HttpStatusCode.Unauthorized);
        }
        public static PaginatedResult<T> BadRequest(List<T> data, int count, int page, int pageSize)
        {
            return new(false, new List<T>(), null, count, page, pageSize, System.Net.HttpStatusCode.BadRequest);
        }
        public HttpStatusCode StatusCode { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public object Meta { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public List<string> Messages { get; set; } = new();

        public bool Succeeded { get; set; }
    }
}
