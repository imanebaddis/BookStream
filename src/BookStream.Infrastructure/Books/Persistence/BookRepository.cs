using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Books.Entities;
using BookStream.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace BookStream.Infrastructure.Books
{
    public class BookRepository : IBookRepository
    {
       
        private readonly BookStreamDbContext _dbcontext;
        private readonly ILogger<BookRepository> _logger;


        BookRepository(ILogger<BookRepository>  logger, BookStreamDbContext dbContext)

        {
            _logger = logger;
            _dbcontext = dbContext;
        }

        public async Task AddAsync(Book book)
        {
            try
            {
                await _dbContext.Books.AddAsync(book);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a book");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try 
            {
                var book = await _dbContext.Books.FindAsync(id);
                if (book is null)
                {
                    throw new KeyNotFoundException($"Book with id {id} not found.");
                }

                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a book");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a book");
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            try
            {
                return await _dbContext.Books.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all books");
                throw;
            }
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {id} not found.");
            }
            return book;
        }

        public Task<bool> UpdateAsync(Book book)
        {
           _dbContext.Update(book);
           int updatedRows = _dbContext.SaveChanges();
            return Task.FromResult(updatedRows > 0);
        }
    }
}
