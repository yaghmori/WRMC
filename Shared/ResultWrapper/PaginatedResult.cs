namespace WRMC.Core.Shared.ResultWrapper
{
    public class PagedResult<T> : Result
    {
        public PagedResult(List<T> data)
        {
            Data = data;
        }

       

        internal PagedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10)
        {
            Data = data;
            CurrentPage = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        public List<T> Data { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public static PagedResult<T> Failure(List<string> messages)
        {
            return new PagedResult<T>(false, default, messages);
        }

        public static PagedResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new PagedResult<T>(true, data, null, count, page, pageSize);
        }


       
    }
}