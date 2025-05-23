using MediatR;
using FluentValidation;
using FluentValidation.Results;
using BookStore.Domain.Entities;
using BookStore.Application.Commands.Blacklist;
using BookStore.Application.Commands.Blacklist.Validators;
using BookStore.Domain.Interfaces;
using BookStore.Application.Interfaces;
namespace BookStore.Application.Blacklist
{
    public class AddUserToBlacklistCommandHandler : IRequestHandler<AddUserToBlacklistCommand, bool>
    {
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IValidator<AddUserToBlacklistCommand> _validator;

        public AddUserToBlacklistCommandHandler(IBlacklistRepository blacklistRepository, IValidator<AddUserToBlacklistCommand> validator)
        {
            _blacklistRepository = blacklistRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(AddUserToBlacklistCommand request, CancellationToken cancellationToken)
        {
            // Validazione del comando
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Verifica se l'utente è già nella blacklist
            var existingEntry = await _blacklistRepository.GetByUserIdAsync(request.UserId);
            if (existingEntry != null)
            {
                throw new Exception("User is already in the blacklist.");
            }

            // Creazione del record di blacklist
            var blacklistEntry = new Blacklist
            {
                UserId = request.UserId,
                Reason = request.Reason,
                AddedDate = DateTime.UtcNow
            };

            // Salvataggio nel database
            await _blacklistRepository.AddAsync(blacklistEntry);
            await _blacklistRepository.SaveChangesAsync();

            return true;
        }
    }
}