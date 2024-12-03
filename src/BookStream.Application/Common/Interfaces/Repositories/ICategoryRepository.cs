using BookStream.Application.Categories.Dtos;
using BookStream.Application.Categories.Queries.GetAllActiveCategories;
using BookStream.Domain.Categories.Entities;
using BookStream.Domain.Common.ResultPattern;

namespace BookStream.Application.Common.Interfaces.Repositories
{
    /// <summary>
    /// Category repository
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<Result<Guid>> CreateCategoryAsync(Category category);

        /// <summary>
        /// Get a category by its unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result<CategoryDto>> GetCategoryByIdAsync(Guid id);

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        Task<Result<IEnumerable<CategoryDto>>> GetCategoriesAsync();

        /// <summary>
        /// Get all active categories
        /// </summary>
        /// <returns></returns>
        Task <Result<IEnumerable<CategoryDto>>> GetActiveCategoriesAsync(GetAllActiveCategoriesWithPaginationQuery request);
    }
}