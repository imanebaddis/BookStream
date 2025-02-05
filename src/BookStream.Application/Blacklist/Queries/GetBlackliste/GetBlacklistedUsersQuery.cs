using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using BookStream.Application.Users.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookStream.Application.Users.Queries.GetBlacklistedUsers
{
    // Query per ottenere la lista degli utenti bloccati
    public class GetBlacklistedUsersQuery : IRequest<Result<IEnumerable<UserDto>>>
    {
        // Parametri per paginazione
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        // Aggiungi eventuali validazioni di base se necessario (opzionale)
        public bool IsValid(out string errorMessage)
        {
            if (PageNumber <= 0)
            {
                errorMessage = "Page number must be greater than 0.";
                return false;
            }

            if (PageSize <= 0 || PageSize > 100)
            {
                errorMessage = "Page size must be between 1 and 100.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }

    // Handler per la query
    public class GetBlacklistedUsersQueryHandler : IRequestHandler<GetBlacklistedUsersQuery, Result<IEnumerable<UserDto>>>
    {
        private readonly ILogger<GetBlacklistedUsersQueryHandler> _logger;
        private readonly IUserRepository _userRepository;

        public GetBlacklistedUsersQueryHandler(ILogger<GetBlacklistedUsersQueryHandler> logger, IUserRepository userRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<Result<IEnumerable<UserDto>>> Handle(GetBlacklistedUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Validazione dei parametri della query
                if (!request.IsValid(out string validationError))
                {
                    _logger.LogWarning("Invalid parameters provided for GetBlacklistedUsersQuery: {ValidationError}", validationError);
                    return Result.Failure<IEnumerable<UserDto>>(validationError);
                }

                // Logging: inizio del processo
                _logger.LogInformation("Fetching blacklisted users: PageNumber={PageNumber}, PageSize={PageSize}", request.PageNumber, request.PageSize);

                // Recupero degli utenti bloccati
                var blacklistedUsers = await _userRepository.GetBlacklistedUsersAsync(request.PageNumber, request.PageSize, cancellationToken);

                // Logging: completamento con successo
                _logger.LogInformation("Successfully fetched {Count} blacklisted users.", blacklistedUsers?.Count() ?? 0);

                return Result.Success(blacklistedUsers);
            }
            catch (Exception ex)
            {
                // Logging: errore durante il processo
                _logger.LogError(ex, "An unexpected error occurred while fetching blacklisted users.");
                return Result.Failure<IEnumerable<UserDto>>("An unexpected error occurred. Please try again later.");
            }
        }
    }
}