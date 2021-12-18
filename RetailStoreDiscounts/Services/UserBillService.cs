using RetailStoreDiscounts.Domain.Interfaces;
using RetailStoreDiscounts.Domain.Model;
using RetailStoreDiscounts.Domain.Responses;

namespace RetailStoreDiscounts.Services
{
    public class UserBillService : IUserBillService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserBillService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<UserBillResponse> GetBill(User user, List<Product> productList)
        {
            int discountPercent = 0;
            decimal? totalBill = 0;
            decimal? totalPrice = 0;
            UserBillResponse userBillResponse = new UserBillResponse(productList, user, totalBill);

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
            }
            var fiveDiscount = totalPrice / 100;
            if (fiveDiscount >1)
            {
                int discountSize = Convert.ToInt32(fiveDiscount);
                var totalDiscount = discountSize * 5;
                totalPrice = totalPrice - totalDiscount;
            }
            totalBill=totalPrice + totalBill;
            userBillResponse.TotalBill = totalBill;

            return userBillResponse;
            
        }
    }
}
