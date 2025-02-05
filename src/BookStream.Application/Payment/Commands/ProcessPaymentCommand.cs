
using MediatR;

namespace BookStream.BookStream.src.BookStream.Application.Payment.Commands

{
    public class ProcessPaymentCommand : IRequest<bool> // Restituisce true se il pagamento è riuscito
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // Es. "CreditCard", "PayPal", "Satispay"
        public string TransactionId { get; set; } // ID transazione del gateway di pagamento
    }
}

