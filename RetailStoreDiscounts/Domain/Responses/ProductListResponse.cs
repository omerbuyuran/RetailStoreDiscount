using RetailStoreDiscounts.Domain.Model;

namespace RetailStoreDiscounts.Domain.Responses
{
    public class ProductListResponse:BaseResponse
    {
        public IEnumerable<Product> ProductList { get; set; }
        private ProductListResponse(bool success, string message,IEnumerable<Product> productList) : base(success, message)
        {
            this.ProductList = productList;
        }
        //Başarılı ise
        public ProductListResponse(IEnumerable<Product> productList) : this(true, string.Empty, productList) { }
        //Başarısız ise
        public ProductListResponse(string message) : this(false, message, null) { }

    }
}
