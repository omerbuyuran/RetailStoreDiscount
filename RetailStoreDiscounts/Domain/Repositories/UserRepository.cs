using Microsoft.EntityFrameworkCore;
using RetailStoreDiscounts.Domain.Interfaces;
using RetailStoreDiscounts.Domain.Model;

namespace RetailStoreDiscounts.Domain.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(RetailStoreDiscountDBContext context) : base(context)
        {
        }

        public async Task AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await context.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task RemoveUserAsync(int userId)
        {
            var user = await GetUserByIdAsync(userId);
            context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
        }
    }
}
