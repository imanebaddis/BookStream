using BookStream.Domain.Common.ResultPattern;
using BookStream.Application.Book.Commands.CreateBook;


{
    public class CreateBookCommand:IRequest<Result<Guid>>
    {
        public required string Name { get; init; }
        
    }
}