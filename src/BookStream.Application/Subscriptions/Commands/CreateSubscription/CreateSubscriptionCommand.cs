using BookStream.Domain.Common.ResultPattern;
namespace BookStream.Application.Subscriptions.Commands.CreateSubscription 
{
    public record CreateSubscriptionCommand:IRequest<Result<Guid>>
    {
        public required string Name { get; init; }
    }
}