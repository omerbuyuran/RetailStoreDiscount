using RetailStoreDiscounts.Domain.Model;

namespace RetailStoreDiscounts.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddUserAsync(User user);
        void UpdateUser(User user);
        Task RemoveUserAsync(int userId);
        Task<User> GetUserByIdAsync(int userId);
    }
}
