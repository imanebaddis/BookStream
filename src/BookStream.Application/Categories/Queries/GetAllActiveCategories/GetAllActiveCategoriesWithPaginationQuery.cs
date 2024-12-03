using BookStream.Application.Categories.Dtos;
using BookStream.Domain.Common.ResultPattern;

namespace BookStream.Application.Categories.Queries.GetAllActiveCategories
{
    public class GetAllActiveCategoriesWithPaginationQuery : IRequest<Result<IEnumerable<CategoryDto>>>
    {
        public int From { get; set; }
        public int To { get; set; }
    }
}