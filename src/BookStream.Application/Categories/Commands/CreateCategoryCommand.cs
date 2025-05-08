using MediatR;

namespace BookStream.Application.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand:IRequest<Guid>
    {
        public required string Name { get; init; }
    }
}
