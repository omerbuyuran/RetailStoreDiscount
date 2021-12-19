using RetailStoreDiscounts.Domain.Model;
using RetailStoreDiscounts.Domain.Responses;

namespace RetailStoreDiscounts.Domain.Interfaces
{
    public interface IUserBillService
    {
        Task<UserBillResponse> GetBill(int userId, List<int> productIdList);
    }
}
