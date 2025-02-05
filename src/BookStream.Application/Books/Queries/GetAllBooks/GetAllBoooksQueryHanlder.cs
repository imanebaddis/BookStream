using BookStream.Application.Books.Dtos;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using MediatR; // Assicurati che MediatR sia incluso
using Microsoft.Extensions.Logging;

namespace BookStream.Application.Books.Queries.GetAllActiveBooks
{
    public class GetAllActiveBooksQueryHandler : IRequestHandler<GetAllActiveBooksWithPaginationQuery, Result<IEnumerable<BookDto>>>
    {
        private readonly ILogger<GetAllActiveBooksQueryHandler> _logger;
        private readonly IBookRepository _bookRepository;

        public GetAllActiveBooksQueryHandler(ILogger<GetAllActiveBooksQueryHandler> logger, IBookRepository bookRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<Result<IEnumerable<BookDto>>> Handle(GetAllActiveBooksWithPaginationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Logging - inizio della chiamata
                _logger.LogInformation("Handling GetAllActiveBooksWithPaginationQuery...");

                // Recupero dei libri attivi
                var books = await _bookRepository.GetActiveBooksAsync(request, cancellationToken);

                // Logging - fine della chiamata con successo
                _logger.LogInformation("GetAllActiveBooksWithPaginationQuery handled successfully.");

                return Result.Success(books);
            }
            catch (Exception ex)
            {
                // Logging in caso di errore
                _logger.LogError(ex, "An error occurred while handling GetAllActiveBooksWithPaginationQuery.");
                return Result.Failure<IEnumerable<BookDto>>("An error occurred while processing the request.");
            }
        }
    }
}