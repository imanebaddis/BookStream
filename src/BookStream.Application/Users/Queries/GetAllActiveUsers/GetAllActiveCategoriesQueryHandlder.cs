using BookStream.Application.Users.Dtos;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging; 


namespace BookStore.Application.Users.Queries.GetAllActiveUsers 
    



namespace BookStream.Application.Users.Queries.GetAllActiveUsers
{
    public class GetAllActiveUsersQueryHandler : IRequestHandler<GetAllActiveUsersWithPaginationQuery, Result<IEnumerable<userDto>>>
    {
        private readonly ILogger<GetAllActiveUsersQueryHanlder> _logger;
        private readonly IuserRepository _userRepository;

        public GetAllActiveUsersQueryHanlder(ILogger<GetAllActiveUsersQueryHanlder> logger, IuserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;    
        }

        public async Task<Result<IEnumerable<userDto>>> Handler(GetAllActiveUsersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetActiveUsersAsync(request);
        }
    }
}