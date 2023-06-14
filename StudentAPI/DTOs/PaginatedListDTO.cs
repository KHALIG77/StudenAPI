namespace StudentAPI.DTOs
{
    public class PaginatedListDTO<T>
    {
        public PaginatedListDTO(List<T> items,int totalPages,int pageIndex)
        {
            Items = items;
            TotalPages = totalPages;
            PageIndex = pageIndex;
            
        }

        public List<T> Items { get; }
        public int TotalPages {get;}
        public int PageIndex {get;}
        public bool HasNext => TotalPages > PageIndex;
        public bool HasPrevious => PageIndex>1;
        
    }
}
