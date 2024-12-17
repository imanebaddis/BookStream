using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using BookStream.Domain.Books.Entities;


namespace BookStream.Application.Books.Commands.CreateBook
{

    public class CreateBookCommandHandler:IRequestHandler<CreateBookCommand,Result<Guid>>
    {
        
        
            
                private readonly Ilogger<CreateBookCommandHandler>_logger;
                private readonly IBookRepository _bookRepository;


                public CreateBookCommandHandler(ILogger<CreateBookCommandHandler> logger, IBookRepository bookRepository)

                {
                    _logger = logger;
                    _bookRepository = bookRepository;

                }

                public async Task<Result<Guid>> Handle(CreateBookCommandHandler request, CancellationToken cancellationToken)

                {
                    var book = new Books(request.Name);
                    var result = await _bookRepository.AddAsync(book);
                    return result;
                }
    }


}