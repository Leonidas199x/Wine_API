namespace Domain
{
    public class PagedList<T>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public T Data { get; set; }

        public int TotalRecords { get; set; }

        public PagedList() { }

        public PagedList(int page, int pageSize, int totalPages,  T data)
        {
            Page = page;
            PageSize = pageSize;
            TotalPages = totalPages;
            Data = data;
        }
    }
}
