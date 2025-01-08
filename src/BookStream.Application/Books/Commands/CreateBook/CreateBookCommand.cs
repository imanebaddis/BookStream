namespace BookStream.Application.Books.Commands.CreateBook
{
    public record CreateBookCommand:IRequest<Guid>
    {
        public required string Name { get; init; }
    }
}