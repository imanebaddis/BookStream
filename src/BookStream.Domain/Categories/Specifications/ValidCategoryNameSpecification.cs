using BookStream.Domain.Common.Interfaces;

namespace BookStream.Domain.Categories.Specifications
{
    public class ValidCategoryNameSpecification : ISpecification<string>
    {
        public string ErrorMessage => "Category name must be less than or equal to 50 characters";

        public bool IsSatisfiedBy(string categoryName)
        {
            return !string.IsNullOrWhiteSpace(categoryName) && categoryName.Length <= 50;
        }
    }
}