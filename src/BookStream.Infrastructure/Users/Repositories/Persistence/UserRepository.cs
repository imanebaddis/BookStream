using Supabase;
using BookStream.Application.Common.Interfaces.Repositories;
using BookStream.Domain.Users.Entities;

namespace BookStream.Infrastructure.Users.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly Client _supabaseClient;

        public UserRepository(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var response = await _supabaseClient
                .From<User>()
                .Where(u => u.Id == id)
                .Single();

            return response;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var response = await _supabaseClient
                .From<User>()
                .Where(u => u.Email == email)
                .Single();

            return response;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var response = await _supabaseClient
                .From<User>()
                .Get();

            return response.Models;
        }

        public async Task<User> CreateAsync(User user)
        {
            var response = await _supabaseClient
                .From<User>()
                .Insert(user);

            return response.Models.FirstOrDefault();
        }

        public async Task<bool> ExistsAsync(string email)
        {
            var response = await _supabaseClient
                .From<User>()
                .Where(u => u.Email == email)
                .Count();

            return response > 0;
        }

        // ... altri metodi
    }
}