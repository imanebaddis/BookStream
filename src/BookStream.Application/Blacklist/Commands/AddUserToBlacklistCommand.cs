using MediatR; // Assicurati che il pacchetto NuGet "MediatR" sia installato
using FluentValidation;
using BookStream.Domain.Entities;
using BookStream.Application.Commands;
namespace BookStream.Application.BlacklistCommand

{
    public class AddUserToBlacklistCommand : IRequest<bool> // Restituisce true se l'operazione è riuscita
    {
        public int UserId { get; set; }
        public required string Reason { get; set; } // Motivo dell'aggiunta alla blacklist
    }


    public class AddUserToBlacklistValidator : AbstractValidator<AddUserToBlacklistCommand>
    {
        public AddUserToBlacklistValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0)
                .WithMessage("UserId deve essere un valore positivo.");
            RuleFor(x => x.Reason).NotEmpty()
                .WithMessage("Reason è obbligatorio.");
        }
    }
}