namespace DataContract
{
    public class PagedList<T>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public T Data { get; set; }
    }
}
