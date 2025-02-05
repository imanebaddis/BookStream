using BookStream.Application.Categories.Dtos;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Common.ResultPattern;
using Microsoft.Extensions.Logging;

namespace BookStream.Application.Categories.Queries.GetSigneCategory
{
    public class GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQuery, Result<CategoryDto>>
    {
        private readonly ILogger<GetSingleCategoryQueryHandler> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public GetSingleCategoryQueryHandler(ILogger<GetSingleCategoryQueryHandler> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<CategoryDto>> Handle(GetSingleCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _categoryRepository.GetCategoryByIdAsync(request.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<CategoryDto>.Failure(Error.Failure("An error occurred while fetching the category","An error occurred while fetching the category"));
         
            }
        }
    }
}using BookStream.Application.Categories.Dtos;
using BookStream.Domain.Common.ResultPattern;

namespace BookStream.Application.Categories.Queries.GetSigneCategory
{
    public class GetSingleCategoryQuery:IRequest<Result<CategoryDto>>
    {
        public Guid Id { get; set; }
    }
}