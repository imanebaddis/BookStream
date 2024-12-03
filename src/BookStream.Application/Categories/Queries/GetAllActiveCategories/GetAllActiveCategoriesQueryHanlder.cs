using BookStream.Application.Categories.Dtos;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using Microsoft.Extensions.Logging;

namespace BookStream.Application.Categories.Queries.GetAllActiveCategories
{
    public class GetAllActiveCategoriesQueryHanlder : IRequestHandler<GetAllActiveCategoriesWithPaginationQuery, Result<IEnumerable<CategoryDto>>>
    {
        private readonly ILogger<GetAllActiveCategoriesQueryHanlder> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public GetAllActiveCategoriesQueryHanlder(ILogger<GetAllActiveCategoriesQueryHanlder> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;    
        }

        public async Task<Result<IEnumerable<CategoryDto>>> Handle(GetAllActiveCategoriesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetActiveCategoriesAsync(request);
        }
    }
}