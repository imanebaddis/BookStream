using BookStream.Application.Categories.Dtos;
using BookStream.Domain.Categories.Entities;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BookStream.Infrastructure.Categories.Persistence.Models
{
    [Table("categories")]
    public class CategoryModel:BaseModel
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the category
        /// </summary>
        [Column("title")]
        public  string Title { get; set; }

        /// <summary>
        /// The status of the category
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// The date and time the entity was created
        /// </summary>
        [Column("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The date and time the entity was last modified
        /// </summary> 
        [Column("modified_at")]
        public DateTimeOffset? ModifiedAt { get; set; }

        /// <summary>
        /// The user who created the entity
        /// </summary>
        [Column("created_by")]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// The user who last modified the entity
        /// </summary>
        [Column("modified_by")]
        public string? ModifiedBy { get; set; }


        public CategoryDto ToDto()
        {
            return new CategoryDto
            {
                Id = Id,
                Name = Title,
                IsActive = IsActive
            };
        }

    }
};