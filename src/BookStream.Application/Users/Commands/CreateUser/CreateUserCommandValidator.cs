using FluentValidation;
using BookStream.Application.Common.Interfaces.Repositories;

namespace BookStream.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("L'email è obbligatoria")
                .EmailAddress().WithMessage("Formato email non valido")
                .MustAsync(async (email, cancellation) =>
                    !await _userRepository.ExistsAsync(email))
                .WithMessage("Questa email è già registrata");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Il nome utente è obbligatorio")
                .MinimumLength(3).WithMessage("Il nome utente deve contenere almeno 3 caratteri")
                .MaximumLength(50).WithMessage("Il nome utente non può superare i 50 caratteri");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La password è obbligatoria")
                .MinimumLength(8).WithMessage("La password deve contenere almeno 8 caratteri")
                .Matches("[A-Z]").WithMessage("La password deve contenere almeno una lettera maiuscola")
                .Matches("[a-z]").WithMessage("La password deve contenere almeno una lettera minuscola")
                .Matches("[0-9]").WithMessage("La password deve contenere almeno un numero")
                .Matches("[^a-zA-Z0-9]").WithMessage("La password deve contenere almeno un carattere speciale");
        }
    }
}