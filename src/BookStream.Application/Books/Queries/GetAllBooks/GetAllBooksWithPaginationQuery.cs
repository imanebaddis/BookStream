using BookStream.Application.Books.Dtos;
using BookStream.Domain.Common.ResultPattern;

namespace BookStream.Application.Books.Queries.GetAllActiveBooks
{
    public class GetAllActiveBooksWithPaginationQuery : IRequest<Result<IEnumerable<BookDto>>>
    {
        public int From { get; set; }
        public int To { get; set; }
    }
}