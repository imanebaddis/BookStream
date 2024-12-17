using BookStream.Application.Books.Dtos;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using Microsoft.Extensions.Logging;

namespace BookStream.Application.Books.Queries.GetAllActiveBooks
{
    public class GetAllActiveBooksQueryHanlder : IRequestHandler<GetAllActiveBooksWithPaginationQuery, Result<IEnumerable<bookDto>>>
    {
        private readonly ILogger<GetAllActiveBooksQueryHanlder> _logger;
        private readonly IbookRepository _bookRepository;

        public GetAllActiveBooksQueryHanlder(ILogger<GetAllActiveBooksQueryHanlder> logger, IbookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;    
        }

        public async Task<Result<IEnumerable<bookDto>>> Handle(GetAllActiveBooksWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetActiveBooksAsync(request);
        }
    }
}