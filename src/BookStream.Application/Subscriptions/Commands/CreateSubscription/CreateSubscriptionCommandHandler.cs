
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Subscriptions.Entities;
using BookStream.Domain.Common.ResultPattern;
using Microsoft.Extensions.Logging;


namespace BookStream.Application.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionommandHandler:IRequestHandler<CreateSubscriptionCommand,Result<Guid>>
    {
        private readonly ILogger<CreateSubscriptionCommandHandler> _logger;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public CreateSubscriptionCommandHandler(ILogger<CreateSubscriptionCommandHandler> logger, ISubscriptionRepository SubscriptionRepository)
        {
            _logger = logger;
            _subscriptionRepository = subscriptionRepository;
        }
        
        public async Task<Result<Guid>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
           var subscription = new Subscription(request.Name);

           var result = await _subscriptionRepository.CreateSubscriptionAsync(subscription);

           return result;
        }
    }
    
}