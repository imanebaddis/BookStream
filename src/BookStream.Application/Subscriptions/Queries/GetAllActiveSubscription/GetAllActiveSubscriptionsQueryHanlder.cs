using BookStream.Application.Subscriptions.Dtos;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Application.Subscription.Dtos;
using BookStream.Domain.Common.ResultPattern;
using Microsoft.Extensions.Logging;

namespace BookStream.Application.Subscriptions.Queries.GetAllActiveSubscription
{
    internal class GetAllActiveSubscriptionsQueryHandlder : IRequestHandler<GetAllActiveSubscriptionsWithPaginationQuery,Result<IEnumerable<SubscriptionDto>>
    {
     private readonly ILogger<GetAllActiveSubscriptionsQueryHandlder> _logger;
     private readonly ISubscriptionRepository _subscriptionRepository;
     public GetAllActiveSubscriptionsQueryHandlder (ILogger<GetAllActiveSubscriptionsQueryHandlder> logger, ICategoryRepository categoryRepository)

   {
            _logger = logger;
            _subscriptionRepository = subscriptionRepository;    
        }

        public async Task<Result<IEnumerable<SubscriptionDtos>>> Handle(GetAllActiveSubscriptionsWithPaginationQuery request, CancellationToken cancellationToken)
        {
          return await _subscriptionsRepository.GetActiveSubscriptionsAsync(request);
        }
    }

    public class Result<T>
    {
    }

    internal interface ISubscriptionRepository
    {
    }
}
