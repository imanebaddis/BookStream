using  BookStream.Application.Common.Interfaces.Repositories;
namespace BookStream.Application.User.Commands.CreateUser


{

    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    
    {
        private readonly IUserRepository _userRepository; 
        public CreateUserCommandValidator(IUserRepository userRepository)

        {
            _userRepository = userRepository;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            
            RuleFor(x => x.Name).MustAsync().WithMessage("The specified name already exists");
            
        }
        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)

        {
            var userResult =  await _userRepository.GetUserAsync();
            if(!userResult.IsSuccess)

            {
                return false;

            }
            return bookResult.Value.All(x => x.Name != name);
            
        }
        


    }
}