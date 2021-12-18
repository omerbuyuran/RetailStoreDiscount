using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreDiscounts.Domain.Interfaces;
using RetailStoreDiscounts.Domain.Model;
using RetailStoreDiscounts.Domain.Request;
using RetailStoreDiscounts.Domain.Responses;

namespace RetailStoreDiscounts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserBillController : ControllerBase
    {
        private readonly IUserBillService userBillService;
        public UserBillController(IUserBillService userBillService)
        {
            this.userBillService = userBillService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBill(UserBillRequest userBillRequest)
        {
            //User user = new User();
            //user.Name = userBillRequest.user.Name;
            //user.Type = userBillRequest.UserType;
            //user.Surname = userBillRequest.Surname;

            //Product product = new Product();
            //product.Category= userBillRequest.Category;
            //product.Price = userBillRequest.Price;

            UserBillResponse userBillResponse = await userBillService.GetBill(userBillRequest.user, userBillRequest.productList);
            if (userBillResponse.Success)
            {
                return Ok(userBillResponse);
            }
            else
            {
                return BadRequest(userBillResponse.Message);
            }
        }
    }
}
