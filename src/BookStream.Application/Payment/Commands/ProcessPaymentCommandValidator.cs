
using FluentValidation;
using BookStore.Application.Commands;

namespace BookStream.BookStream.src.BookStream.Application.Payment.Commands

{
    public class ProcessPaymentCommandValidator : AbstractValidator<ProcessPaymentCommand>
    {
        public ProcessPaymentCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .GreaterThan(0).WithMessage("User ID must be greater than 0.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required.")
                .Must(BeAValidPaymentMethod).WithMessage("Invalid payment method.");

            RuleFor(x => x.TransactionId)
                .NotEmpty().WithMessage("Transaction ID is required.");
        }

        private bool BeAValidPaymentMethod(string paymentMethod)
        {
            var validMethods = new[] { "CreditCard", "PayPal", "Satispay" };
            return validMethods.Contains(paymentMethod);
        }
    }
}