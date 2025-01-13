namespace BookStream.Web.Users.Dtos
{
    public class GetAllActiveUsersWithPaginationRequest
    {
         public string Username { get; set;}
         public string Email { get; set;}
         public string Role { get; set;}
        public int PageNumber { get; set; }
        //public int PageSize { get; set; }
    }
}