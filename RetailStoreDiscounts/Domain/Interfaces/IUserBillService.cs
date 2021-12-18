using RetailStoreDiscounts.Domain.Model;
using RetailStoreDiscounts.Domain.Responses;

namespace RetailStoreDiscounts.Domain.Interfaces
{
    public interface IUserBillService
    {
        Task<UserBillResponse> GetBill(User user, List<Product> product);
    }
}
