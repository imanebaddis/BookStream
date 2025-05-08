using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Subscriptions.Entities;
using BookStream.Domain.Common.ResultPattern;
using Microsoft.Extensions.Logging;
using FluentValidation;
using MediatR;
using BookStream.Application.Common.Interfaces.Services;


namespace BookStream.Application.Subscriptions.Commands.CreateSubscription
{

    public class CreateSubscriptionCommandHandler
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IValidator<CreateSubscriptionCommand> _validator;

        public CreateSubscriptionCommandHandler(ISubscriptionService subscriptionService,
            IValidator<CreateSubscriptionCommand> validator)
        {
            _subscriptionService = subscriptionService;
            _validator = validator;
        }

        public void Handle(CreateSubscriptionCommand command)
        {
            var validationResult = _validator.Validate(command);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var subscription = new Subscription
            {
                Type = command.Type,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                IsActive = true
            };

            _subscriptionService.CreateSubscription(subscription);
        }
    }
}