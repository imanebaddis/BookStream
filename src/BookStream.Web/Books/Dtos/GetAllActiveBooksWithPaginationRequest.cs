namespace BookStream.Web.Books.Dtos
{
    public class GetAllActiveBooksWithPaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}