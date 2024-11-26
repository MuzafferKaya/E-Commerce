namespace Dto.Request
{
    public class QueryStringParameters
    {
        private const int MaxPageSize = 100;
        private const int DefaultPageSize = 10;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = DefaultPageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
