using System;
using System.Threading;
using System.Threading.Tasks;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using BookStream.Domain.Users.Entities;
using Microsoft.Extensions.Logging; // Make sure this is included
using BCrypt.Net;

namespace BookStream.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Log the creation attempt
            _logger.LogInformation("Creating user with email: {Email}", request.Email);

            // Check if the email is already in use
            var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
            {
                _logger.LogWarning("Attempt to create user failed: the email {Email} is already in use", request.Email);
                return Result.Failure<Guid>("L'email è già in uso");
            }




            // Create new user
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = HashPassword(request.Password), // Implement password hashing
                Username = request.Username,
                Role = request.Role
            };

            var result = await _userRepository.AddAsync(user);
            if (result.IsSuccess)
            {
                _logger.LogInformation("User created successfully with ID: {UserId}", result.Value);
            }
            else
            {
                _logger.LogError("Failed to create user: {Error}", result.Error);
            }

            return result;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify the provided password with the stored hash
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
