namespace BookStream.BookStream.src.BookStream.Application.Blacklist.Commands

{
    public class AddUserToBlacklistCommandValidator : AbstractValidator<AddUserToBlacklistCommand>
    {
        public AddUserToBlacklistCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .GreaterThan(0).WithMessage("User ID must be greater than 0.");

            RuleFor(x => x.Reason)
                .NotEmpty().WithMessage("Reason is required.")
                .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters.");
        }
    }
}