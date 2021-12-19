using RetailStoreDiscounts.Domain.Interfaces;
using RetailStoreDiscounts.Domain.Model;
using RetailStoreDiscounts.Domain.Responses;

namespace RetailStoreDiscounts.Services
{
    public class UserBillService : IUserBillService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository productRepository;
        private readonly IUserRepository userRepository;
        public UserBillService(IUnitOfWork unitOfWork, IProductRepository productRepository, IUserRepository userRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }

        public async Task<UserBillResponse> GetBill(int userId, List<int> productIdList)
        {
            int discountPercent = 0;
            decimal? totalBill = 0;
            decimal? totalPrice = 0;
            decimal? privateCustomerDiscountAmount = 0;
            decimal? billDiscountAmount = 0;
            decimal? totalDiscountAmount = 0;
            //user bilgisi alınıyor
            User user = await userRepository.GetUserByIdAsync(userId);
            List<Product> productList = new List<Product>();
            if (productIdList.Count >0)
            {
                foreach (var item in productIdList)
                {
                    //ürünler bulunuyor
                    Product product = await productRepository.GetProductByIdAsync(item);
                    productList.Add(product);
                }
            }
            
            UserBillResponse userBillResponse = new UserBillResponse(productList, user, totalBill, privateCustomerDiscountAmount,billDiscountAmount,totalDiscountAmount);

            if (!string.IsNullOrEmpty(user.Type) && productList.Count > 0)
            {
                user.Type = user.Type.ToLower();            

                if (user.Type.Equals("employee"))
                {
                    discountPercent = 30;
                    foreach (var item in productList)
                    {
                        if (item.Category.ToLower()!="grocery")
                        {
                            //grocery olmayan ürünlerin toplam fiyatı
                            totalPrice = totalPrice + item.Price;
                        }
                        else
                        {
                            //grocerylerin toplam fiyatı
                            totalBill = totalBill + item.Price;
                        }
                    }
                    //totalPrice a yüzde 30 indirim
                    privateCustomerDiscountAmount = (totalPrice * 30) / 100;
                    totalPrice = (totalPrice * 70)/100;
                    totalBill = totalPrice + totalBill;
                }
                else if (user.Type.Equals("affiliate"))
                {
                    discountPercent = 10;
                    foreach (var item in productList)
                    {
                        if (item.Category.ToLower() != "grocery")
                        {
                            //grocery olmayan ürünlerin toplam fiyatı
                            totalPrice = totalPrice + item.Price;
                        }
                        else
                        {
                            //grocerylerin toplam fiyatı
                            totalBill = totalBill + item.Price;
                        }
                    }
                    //totalPrice a yüzde 10 indirim
                    privateCustomerDiscountAmount = (totalPrice * 10) / 100;
                    totalPrice = (totalPrice * 90) / 100;
                    totalBill = totalPrice + totalBill;
                }
                else if (user.Type.Equals("customer"))
                {
                    discountPercent = 5;
                    foreach (var item in productList)
                    {
                        if (item.Category.ToLower() != "grocery")
                        {
                            //grocery olmayan ürünlerin toplam fiyatı
                            totalPrice = totalPrice + item.Price;
                        }
                        else
                        {
                            //grocerylerin toplam fiyatı
                            totalBill = totalBill + item.Price;
                        }
                    }
                    //totalPrice a yüzde 5 indirim
                    privateCustomerDiscountAmount = (totalPrice * 5) / 100;
                    totalPrice = (totalPrice * 95) / 100;
                    totalBill = totalPrice + totalBill;
                }
                else
                {
                    foreach (var item in productList)
                    {
                        if (item.Category.ToLower() != "grocery")
                        {
                            //grocery olmayan ürünlerin toplam fiyatı
                            totalPrice = totalPrice + item.Price;
                        }
                        else
                        {
                            //grocerylerin toplam fiyatı
                            totalBill = totalBill + item.Price;
                        }
                    }
                    totalBill = totalPrice + totalBill;
                }
            }
            var fiveDiscount = totalBill / 100;
            if (fiveDiscount >1)
            {
                int discountSize = Convert.ToInt32(fiveDiscount);
                billDiscountAmount = discountSize * 5;
                totalBill = totalBill - billDiscountAmount;
            }
            totalDiscountAmount = billDiscountAmount + privateCustomerDiscountAmount;

            userBillResponse.TotalBill = totalBill;
            userBillResponse.PrivateCustomerDiscountAmount = privateCustomerDiscountAmount;
            userBillResponse.BillDiscountAmount = billDiscountAmount;
            userBillResponse.TotalDiscountAmount = totalDiscountAmount;

            return userBillResponse;
            
        }
    }
}
