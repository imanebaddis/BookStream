using BookStream.Domain.Common.ResultPattern;

namespace BookStream.Application.Subscriptions.Commands.CreateSubscription
{
    public record CreateSubscriptionCommand : IRequest<Result<Guid>>
    {
        public required string Name { get; init; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CancelSubscriptionCommand
    {
        public int SubscriptionId { get; set; }
    }

}