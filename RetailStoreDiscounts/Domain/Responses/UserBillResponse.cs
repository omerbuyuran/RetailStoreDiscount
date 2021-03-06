using RetailStoreDiscounts.Domain.Model;

namespace RetailStoreDiscounts.Domain.Responses
{
    public class UserBillResponse:BaseResponse
    {
        public List<Product> ProductList { get; set; }
        public User User { get; set; }
        public decimal? TotalBill { get; set; }
        public decimal? PrivateCustomerDiscountAmount { get; set; }
        public decimal? BillDiscountAmount { get; set; }
        public decimal? TotalDiscountAmount { get; set; }
        private UserBillResponse(bool success, string message, List<Product> productList, User user,decimal? totalBill, decimal? privateCustomerDiscountAmount, decimal? billDiscountAmount, decimal? totalDiscountAmount) : base(success, message)
        {
            this.ProductList = productList;
            this.User = user;
            this.TotalBill = totalBill;
            this.PrivateCustomerDiscountAmount = privateCustomerDiscountAmount;
            this.BillDiscountAmount = billDiscountAmount;
            this.TotalDiscountAmount = totalDiscountAmount;
        }
        //Başarılı ise
        public UserBillResponse(List<Product> productList, User user, decimal? totalBill, decimal? privateCustomerDiscountAmount, decimal? billDiscountAmount, decimal? totalDiscountAmount) : this(true, string.Empty, productList, user, totalBill, privateCustomerDiscountAmount, billDiscountAmount, totalDiscountAmount) { }
        //Başarısız ise
        public UserBillResponse(string message) : this(false, message, null,null,null,null,null,null) { }
    }
}
