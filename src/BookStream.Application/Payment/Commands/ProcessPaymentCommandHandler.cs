using MediatR;
using FluentValidation;
using BookStore.Domain.Entities;
using BookStore.Application.Commands;
using BookStore.Application.Validators;
using BookStore.Domain.Interfaces;


namespace BookStream.BookStream.src.BookStream.Application.Payment.Commands;

{
    public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, bool>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ProcessPaymentCommandValidator _validator;

        public ProcessPaymentCommandHandler(IPaymentRepository paymentRepository, ProcessPaymentCommandValidator validator)
        {
            _paymentRepository = paymentRepository;
            _validator = validator;
        }

        public async Task<bool> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
        {
            // Validazione del comando
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Simulazione dell'integrazione con un gateway di pagamento
            var paymentSuccess = await ProcessPaymentWithGateway(request);
            if (!paymentSuccess)
            {
                throw new Exception("Payment processing failed.");
            }

            // Creazione del record di pagamento
            var payment = new Payment
            {
                UserId = request.UserId,
                Amount = request.Amount,
                PaymentMethod = request.PaymentMethod,
                TransactionId = request.TransactionId,
                Status = "Completed",
                PaymentDate = DateTime.UtcNow
            };

            // Salvataggio nel database
            await _paymentRepository.AddAsync(payment);
            await _paymentRepository.SaveChangesAsync();

            return true;
        }

        private async Task<bool> ProcessPaymentWithGateway(ProcessPaymentCommand request)
        {
            // Simulazione di una chiamata a un gateway di pagamento esterno
            await Task.Delay(1000); // Simula un ritardo di rete
            return true; // Simula un pagamento riuscito
        }
    }
}