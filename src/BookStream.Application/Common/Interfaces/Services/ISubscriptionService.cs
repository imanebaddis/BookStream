namespace BookStream.Application.Common.Interfaces.Services
{
    public interface ISubscriptionService
    {
        Task<SubscriptionDto> CreateSubscriptionAsync(CreateSubscriptionCommand command);
        Task<SubscriptionDto> GetSubscriptionByIdAsync(int id);
        Task<IEnumerable<SubscriptionDto>> GetAllSubscriptionsAsync();
        Task<SubscriptionDto> UpdateSubscriptionAsync(UpdateSubscriptionCommand command);
        Task DeleteSubscriptionAsync(int id);
    }
}