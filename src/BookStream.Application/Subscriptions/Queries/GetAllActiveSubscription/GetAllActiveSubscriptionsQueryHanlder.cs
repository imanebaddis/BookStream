using BookStream.Application.Subscriptions.Dtos;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using MediatR; // Assicurati di importare MediatR
using Microsoft.Extensions.Logging;

namespace BookStream.Application.Subscriptions.Queries.GetAllActiveSubscriptions
{
    internal class GetAllActiveSubscriptionsQueryHandler : IRequestHandler<GetAllActiveSubscriptionsWithPaginationQuery, Result<IEnumerable<SubscriptionDto>>>
    {
        private readonly ILogger<GetAllActiveSubscriptionsQueryHandler> _logger;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public GetAllActiveSubscriptionsQueryHandler(ILogger<GetAllActiveSubscriptionsQueryHandler> logger, ISubscriptionRepository subscriptionRepository)
        {
            _logger = logger;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Result<IEnumerable<SubscriptionDto>>> Handle(GetAllActiveSubscriptionsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var subscriptions = await _subscriptionRepository.GetActiveSubscriptionsAsync(request, cancellationToken);
                return Result<IEnumerable<SubscriptionDto>>.Success(subscriptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting active subscriptions");
                return Result<IEnumerable<SubscriptionDto>>.Failure("An error occurred while processing your request.");
            }
        }
    }

    // Esempio di definizione della classe Result<T>
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T Value { get; private set; }
        public string Error { get; private set; }

        public static Result<T> Success(T value)
        {
            return new Result<T> { IsSuccess = true, Value = value };
        }

        public static Result<T> Failure(string error)
        {
            return new Result<T> { IsSuccess = false, Error = error };
        }
    }

    // Interfaccia del repository
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<SubscriptionDto>> GetActiveSubscriptionsAsync(GetAllActiveSubscriptionsWithPaginationQuery query, CancellationToken cancellationToken);
    }

    // Query per ottenere le sottoscrizioni (aggiunta)
    public class GetAllActiveSubscriptionsWithPaginationQuery : IRequest<Result<IEnumerable<SubscriptionDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
    public class Result<T>
    {
    }

    internal interface ISubscriptionRepository
    {
    }
}
