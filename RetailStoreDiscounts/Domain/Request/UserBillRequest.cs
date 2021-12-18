using RetailStoreDiscounts.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace RetailStoreDiscounts.Domain.Request
{
    public class UserBillRequest
    {
        //[Required]
        public User user { get; set; }
        //[Required]
        public List<Product> productList { get; set; }
    }
}
