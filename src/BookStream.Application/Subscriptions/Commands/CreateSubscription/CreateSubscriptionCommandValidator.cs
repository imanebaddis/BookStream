namespace BookStream.BookStream.src.BookStream.Application.Subscriptions.Commands.CreateSubscription
{
    /// <summary>
    /// Create subscription command validator
    /// </summary>
    public class CreateSubscriptionCommandValidator:AbstractValidator<CreateSubscriptionCommand>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        /// <summary>
        /// Create a new instance of the CreatesubscriptionCommandValidator
        /// </summary>
        /// <param name="subscriptionRepository"></param>
        public CreatesubscriptionCommandValidator(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MustAsync(BeUniqueName).WithMessage("The specified name already exists");
        }
        
        
        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            var subscriptionsResult = await _subscriptionRepository.GetSubscriptionAsync();
            if(!subscriptionsResult.IsSuccess)
            {
                return false;
            }
            
            return subscriptionResult.Value.All(x => x.Name != name);
        }
    }
}