
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStream.BookStream.src.BookStream.Application.Blacklist.Queries.GetBlacklist
{
    public class GetBlacklistUsersQuery : IRequest<List<string>>
    {
        // Add any filters or properties here if needed in the future, e.g., paging or search criteria
    }

    public class GetBlacklistUsersQueryHandler : IRequestHandler<GetBlacklistUsersQuery, List<string>>
    {
        private readonly IBlacklistRepository _blacklistRepository;

        public GetBlacklistUsersQueryHandler(IBlacklistRepository blacklistRepository)
        {
            _blacklistRepository = blacklistRepository;
        }

        public async Task<List<string>> Handle(GetBlacklistUsersQuery request, CancellationToken cancellationToken)
        {
            // Assuming IBlacklistRepository provides a method to retrieve all blacklisted users
            var blacklistedUsers = await _blacklistRepository.GetAllBlacklistedUsersAsync(cancellationToken);

            return blacklistedUsers.ToList(); // Convert to List<string>, if not already
        }
    }

    public interface IBlacklistRepository
    {
        Task<IEnumerable<string>> GetAllBlacklistedUsersAsync(CancellationToken cancellationToken);
    }
}