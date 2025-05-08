
using FluentValidation;
using BookStream.Web.Books.Dtos;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Il titolo è obbligatorio")
            .MaximumLength(200).WithMessage("Il titolo non può superare i 200 caratteri");
    }
}