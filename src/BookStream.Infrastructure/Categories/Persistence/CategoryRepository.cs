using BookStream.Application.Categories.Dtos;
using BookStream.Application.Categories.Queries.GetAllActiveCategories;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Categories.Entities;
using BookStream.Domain.Common.ResultPattern;
using BookStream.Infrastructure.Categories.Persistence.Models;
using Microsoft.Extensions.Logging;
using Supabase;


/*namespace BookStream.Infrastructure.Categories.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
         private readonly Supabase.Client _supabaseClient;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(ILogger<CategoryRepository> logger, Supabase.Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
            _logger = logger;
        }

        public async Task<Result<Guid>> CreateCategoryAsync(Category category)
        {
            try
            {
                var result = await _supabaseClient.From<CategoryModel>().Insert(new CategoryModel
                {
                    Id = category.Id,
                    Title = category.Name,
                    IsActive = category.IsActive,
                    CreatedAt = category.CreatedAt,
                    ModifiedAt = category.ModifiedAt,
                    CreatedBy = category.CreatedBy,
                    ModifiedBy = category.ModifiedBy
                });

                var insertedCategory = result.Models.FirstOrDefault();

                if(insertedCategory is null)
                {
                    return Result<Guid>.Failure(Error.Failure("An error occurred while creating the category","An error occurred while creating the category"));
                }

                return Result<Guid>.Success(insertedCategory.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occurred while creating the category");
                return Result<Guid>.Failure(Error.Failure("Creation error","An error occurred while creating the category"));
            }

        }

        public async Task<Result<IEnumerable<CategoryDto>>> GetActiveCategoriesAsync(GetAllActiveCategoriesWithPaginationQuery request)
        {
            try
            {
                var result = await _supabaseClient
                .From<CategoryModel>()
                .Where(x=>x.IsActive== true)
                .Range(request.From,request.To)
                .Get();

                return Result<IEnumerable<CategoryDto>>.Success(result.Models.Select(x=>x.ToDto()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occurred while fetching active categories");
                return Result<IEnumerable<CategoryDto>>.Failure(Error.Failure("Featching error","An error occurred while fetching active categories"));
                throw;
            }

        }

        public async Task<Result<IEnumerable<CategoryDto>>> GetCategoriesAsync()
        {
            try
            {
                var result = await _supabaseClient
                .From<CategoryModel>()
                .Get();

                return Result<IEnumerable<CategoryDto>>.Success(result.Models.Select(x=>x.ToDto())); 
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex,"An error occurred while fetching categories");
                return Result<IEnumerable<CategoryDto>>.Failure(Error.Failure("An error occurred while fetching categories",ex.Message));
            }

        }

        public async Task<Result<CategoryDto>> GetCategoryByIdAsync(Guid id)
        {
            try
            {
                var result = await _supabaseClient
                .From<CategoryModel>()
                .Where(x=>x.Id== id)
                .Select(x=>new object[]{x.Id,x.Title,x.IsActive})
                .Single();

                if(result is null)
                {
                    return Result<CategoryDto>.Failure(Error.NotFound("Category not found","No category found with the specified id"));
                }

                return Result<CategoryDto>.Success(result.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occurred while fetching the category");
                return Result<CategoryDto>.Failure(Error.Failure("An error occurred while fetching the category",ex.Message));
            }
        }
    }
}*/

using Supabase.Postgrest.Attributes;

namespace BookStream.Infrastructure.Categories.Persistence.Models
{
    [Table("categories")]
    public class CategoryModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        // ... altri campi
    }
}