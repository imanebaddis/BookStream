namespace BookStream.web.Subscriptions.Dtos
{
    public class GetAllActiveSubscriptionsWithPaginationRequest
    {
        public int PageNumber { get; set;}
        public int PageSize{ get; set;}
    }
}