using RetailStoreDiscounts.Domain.Model;

namespace RetailStoreDiscounts.Domain.Responses
{
    public class UserBillResponse:BaseResponse
    {
        public List<Product> ProductList { get; set; }
        public User User { get; set; }
        public decimal? TotalBill { get; set; }
        private UserBillResponse(bool success, string message, List<Product> productList, User user,decimal? totalBill) : base(success, message)
        {
            this.ProductList = productList;
            this.User = user;
            this.TotalBill = totalBill;
        }
        //Başarılı ise
        public UserBillResponse(List<Product> productList, User user, decimal? totalBill) : this(true, string.Empty, productList, user, totalBill) { }
        //Başarısız ise
        public UserBillResponse(string message) : this(false, message, null,null,null) { }
    }
}
