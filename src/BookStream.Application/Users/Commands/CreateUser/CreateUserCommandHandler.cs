using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using BookStream.Domain.Users.Entities;


namespace BookStream.Application.Users.Commands.CreateUser
{

    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand,Result<Guid>>
    {
        
        
            
                private readonly Ilogger<CreateUserCommandHandler>_logger;
                private readonly IUserRepository _userRepository;


                public CreateBookCommandHandler(ILogger<CreateUserCommandHandler> logger, IUserRepository userRepository)

                {
                    _logger = logger;
                    _userRepository = userRepository;

                }

                public async Task<Result<Guid>> Handle(CreateUserCommandHandler request, CancellationToken cancellationToken)

                {
                    var user = new Users(request.Name);
                    var result = await _bookRepository.AddAsync(user);
                    return result;
                }
    }


}