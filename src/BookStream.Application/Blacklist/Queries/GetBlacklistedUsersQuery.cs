
using MediatR;
namespace BookStream.BookStream.src.BookStream.Application.Blacklist.Queries
{
    public class GetBlacklistedUsersQuery : IRequest<List<BlacklistDTO>> // Restituisce una lista di DTOs
    {
    }
}