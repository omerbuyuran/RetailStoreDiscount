using RetailStoreDiscounts.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace RetailStoreDiscounts.Domain.Request
{
    public class UserBillRequest
    {
        //[Required]
        public int userId { get; set; }
        //[Required]
        public List<int> productIdList { get; set; }
    }
}
