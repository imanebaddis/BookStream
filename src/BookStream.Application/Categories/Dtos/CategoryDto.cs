using BookStream.Application.Categories.Dtos;

namespace BookStream.BookStream.src.BookStream.Application.Categories.Dtos
{
    /// <summary>
    /// Category
    /// </summary>
    public class CategoryDto
    {
        /// <summary>
        /// The unique identifier for the category
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the category
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The status of the category
        /// </summary>
        public bool IsActive { get; set; }
    }
}