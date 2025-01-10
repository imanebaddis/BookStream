using BookStream.Application.Subscriptions.Dtos;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using Microsoft.Extensions.Logging;

namespace BookStream.Application.Subscriptions.Queries.GetAllActiveSubscription
{
   
    public class GetAllActiveSubscriptionQueryHanlder : IRequestHandler<GetAllActiveSubscriptionsWithPaginationQuery, Result<IEnumerable<SubscriptionDto>>
    {
     private readonly ILogger<GetAllActiveSubscriptionsQueryHanlder> _logger;
     private readonly ISubscriptionRepository _subscriptionRepository;
     public GetAllActiveSubscriptionQueryHanlder (ILogger<GetAllActiveCategoriesQueryHanlder> logger, ICategoryRepository categoryRepository)

   {
            _logger = logger;
            _subscriptionRepository = subscriptionRepository;    
        }

        public async Task<Result<IEnumerable<SubscriptionDto>>> Handle(GetAllActiveSubscriptionsWithPaginationQuery request, CancellationToken cancellationToken)
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
