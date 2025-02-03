using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Categories.Entities;
using Microsoft.Extensions.Logging;





namespace BookStream.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand,Guid>
    {
        private readonly ILogger<CreateCategoryCommandHandler> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ILogger<CreateCategoryCommandHandler> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }
        
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);

            await _categoryRepository.CreateCategoryAsync(category);

            return category.Id;
        }
    }
    
}