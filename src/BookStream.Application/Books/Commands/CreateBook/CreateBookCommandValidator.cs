using  BookStream.Application.Common.Interfaces.Repositories;
namespace BookStream.Application.Book.Commands.CreateBook

{
    public class CreateBookCommandValidator:AbstractValidator<CreateBookCommand>

    {
        private readonly IBookRepository _bookRepository;



        public CreateBookCommandValidator(IBookRepository bookRepository)

        {
            _bookRepository = bookRepository;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required");

            RuleFor(x => x.Name).MustAsync().WithMessage("The specified name already exists");
            
        }
        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)

        {
            var bookResult =  await _bookRepository.GetBookAsync();
            if(!bookResult.IsSuccess)

            {
                return false;

            }
            return bookResult.Value.All(x => x.Name != name);
            
        }
        


    }
}