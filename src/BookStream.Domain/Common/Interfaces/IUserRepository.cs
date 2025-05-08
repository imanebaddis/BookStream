using BookStream.Domain.Users.Entities;

namespace BookStream.Application.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(string email);
    }
}