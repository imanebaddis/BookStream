using MediatR;

namespace BookStream.BookStream.src.BookStream.Application.Blacklist

{
    public class AddUserToBlacklistCommand : IRequest<bool> // Restituisce true se l'operazione è riuscita
    {
        public int UserId { get; set; }
        public string Reason { get; set; } // Motivo dell'aggiunta alla blacklist
    }

    public interface IRequest<T>
    {
    }
}