using System;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using BookStream.Domain.Users.Entities;
using BCrypt.Net; //assicurarsi di aver questo using 


namespace BookStream.Application.Users.Commands.CreateUser
{

    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand,Result<Guid>>
    {
        
        
            
                private readonly Ilogger<CreateUserCommandHandler>_logger;
                private readonly IUserRepository _userRepository;


                public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IUserRepository userRepository)

                {
                    _logger = logger;
                    _userRepository = userRepository;

                }

                public async Task<Result<Guid>> Handle(CreateUserCommandHandler request, CancellationToken cancellationToken)



           // Log the creation attempt


           _logger.LogInformation("Creating user with email: {Email}",
           request.Email);



          // Verifica se l'email è gia in uso 
           
           var existingUser = await
           _userRepository.GetUserByEmailAsync(request.Email);
           if (existingUser != null)
           {

            _logger.LogWarning("Tentativo di creazione utente fallito : l'email {Email} è 
            gia in uso", request.Email);
            return Result.Failure<Guid>("L'email è gia in uso");
           }




           // Implement necessary validations here (e.g., check if email is already in use)
            // If the email is already in use, you can return a failure result
            // Example:
            // var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            // if (existingUser != null)
            // {
            //     return Result.Fail<Guid>("Email is already in use.");
            // }
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


                    // BCrypt.Net.BCrypt.HashPassword(password);
                     return BCrypt.Net.BCrypt.HashPassword(password);
                }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Verifica la password fornita con l'hash memorizzato
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                }
    }


}}