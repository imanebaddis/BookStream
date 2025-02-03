namespace BookStream.Application.Books.Commands.CreateBook
{
    /// <summary>
    /// Comando per creare un nuovo libro.
    /// </summary>
    public record CreateBookCommand : IRequest<Guid>
    {
        /// <summary>
        /// Nome del libro. Questo campo è obbligatorio.
        /// </summary>
        public required string Name { get; init; }
        
        // Se necessario, aggiungi altre proprietà qui
    }
}