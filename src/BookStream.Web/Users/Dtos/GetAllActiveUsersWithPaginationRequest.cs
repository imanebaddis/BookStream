namespace BookStream.Web.Users.Dtos
{
    public class GetAllActiveUsersWithPaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}