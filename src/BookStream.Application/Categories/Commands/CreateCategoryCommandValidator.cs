using BookStream.Application.Common.Interfaces.Repositories;

namespace BookStream.Application.Categories.Commands.CreateCategory
{
    /// <summary>
    /// Create category command validator
    /// </summary>
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Create a new instance of the CreateCategoryCommandValidator
        /// </summary>
        /// <param name="categoryRepository"></param>
        public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MustAsync(BeUniqueName).WithMessage("The specified name already exists");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return categories.All(x => x.Name != name);
        }
    }
}