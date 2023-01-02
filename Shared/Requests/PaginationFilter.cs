namespace WRMC.Core.Shared.Requests
{
    public class PaginationFilter
    {
        const int maxPageSize = 100;
        public int Page { get; set; } = 0;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value > maxPageSize ? maxPageSize : value;
            }
        }
    }
}
