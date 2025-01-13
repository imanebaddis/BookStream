using System;
using System.Threading;
using System.Threading.Tasks;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using BCrypt.Net;
using Microsoft.Extensions.Logging;

namespace BookStream.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<Guid>>
    {
        private readonly ILogger<LoginUserCommandHandler> _logger;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(ILogger<LoginUserCommandHandler> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<Result<Guid>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Attempting to login user with email: {Email}", request.Email);

            // Recupera l'utente dal repository
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                _logger.LogWarning("Login failed: user with email {Email} not found", request.Email);
                return Result.Failure<Guid>("Email o password errati.");
            }

            // Verifica la password
            if (!VerifyPassword(request.Password, user.Password))
            {
                _logger.LogWarning("Login failed: incorrect password for email {Email}", request.Email);
                return Result.Failure<Guid>("Email o password errati.");
            }

            _logger.LogInformation("User logged in successfully with ID: {UserId}", user.Id);
            return Result.Success(user.Id);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
