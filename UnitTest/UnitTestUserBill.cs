using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetailStoreDiscounts.Controllers;
using RetailStoreDiscounts.Domain.Interfaces;
using RetailStoreDiscounts.Domain.Model;
using RetailStoreDiscounts.Domain.Request;
using RetailStoreDiscounts.Domain.Responses;
using RetailStoreDiscounts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UnitTestUserBill
    {
        private readonly IUserBillService userBillService;
        public UnitTestUserBill(IUserBillService userBillService)
        {
            this.userBillService = userBillService;
        }
        [TestMethod]
        public void TestUserBill()
        {

            UserBillRequest userBillRequest = new UserBillRequest();
            userBillRequest.userId = 2;
            userBillRequest.productIdList.Add(1);
            userBillRequest.productIdList.Add(2);
            UserBillResponse userBillResponseActual = userBillService.GetBill(userBillRequest.userId, userBillRequest.productIdList).Result;
            Assert.IsNotNull(userBillResponseActual);

            List<Product> productList = new List<Product>();
            User user = new User();
            decimal? totalBill = 0;
            decimal? privateCustomerDiscountAmount = 0;
            decimal? billDiscountAmount = 0;
            decimal? totalDiscountAmount = 0;

            UserBillResponse expectedUserBillResponse = new UserBillResponse(productList, user, totalBill, privateCustomerDiscountAmount, billDiscountAmount, totalDiscountAmount);
            productList.Add(new Product
            {
                Id = 1,
                Name = "Smart Phone",
                Category = "Technology",
                Price =5000
            });
            productList.Add(new Product
            {
                Id = 2,
                Name = "Milk",
                Category = "Grocery",
                Price = 20
            });
            user = new User
            {
                Id = 3,
                Name = null,
                Surname = "Mutlu",
                Type = "affiliate"
            };
            totalBill = 4295;
            privateCustomerDiscountAmount = 500;
            billDiscountAmount = 225;
            totalDiscountAmount = 725;
            expectedUserBillResponse.ProductList = productList;
            expectedUserBillResponse.User = user;
            expectedUserBillResponse.TotalBill = totalBill;
            expectedUserBillResponse.PrivateCustomerDiscountAmount = privateCustomerDiscountAmount;
            expectedUserBillResponse.BillDiscountAmount = billDiscountAmount;
            expectedUserBillResponse.TotalDiscountAmount = totalDiscountAmount;
            Assert.AreEqual(expectedUserBillResponse, userBillResponseActual);
            
        }
    }
}