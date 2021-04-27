namespace Domain
{
    public class PagedList<T>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public T Data { get; set; }

        public PagedList(int page, int pageSize, T data)
        {
            Page = page;
            PageSize = pageSize;
            Data = data;
        }
    }
}
