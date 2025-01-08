using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Books.Entities;
using Microsoft.Extensions.Logging;


namespace BookStream.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly ILogger<CreateBookCommandHandler> _logger;
        private readonly IbookRepository _bookRepository;

        public CreateBookCommandHandler(ILogger<CreateBookCommandHandler> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Name);

            await _bookRepository.CreateBookAsync(book);

            return book.Id;
        }
    }

}