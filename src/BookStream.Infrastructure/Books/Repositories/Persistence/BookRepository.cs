using Supabase;
using BookStream.Domain.Books.Entities;

namespace BookStream.Infrastructure.Books.Persistence
{
    public class BookRepository : IBookRepository
    {
        private readonly Client _supabaseClient;

        public BookRepository(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var response = await _supabaseClient
                .From<Book>()
                .Where(x => x.Id == id)
                .Single();

            return response;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var response = await _supabaseClient
                .From<Book>()
                .Get();

            return response.Models;
        }

        public async Task<Book> AddAsync(Book book)
        {
            var response = await _supabaseClient
                .From<Book>()
                .Insert(book);

            return response.Models.FirstOrDefault();
        }

        // ... altri metodi
    }
}