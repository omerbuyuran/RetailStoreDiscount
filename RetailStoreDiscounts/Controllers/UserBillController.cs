using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailStoreDiscounts.Domain.Interfaces;
using RetailStoreDiscounts.Domain.Model;
using RetailStoreDiscounts.Domain.Request;
using RetailStoreDiscounts.Domain.Responses;
using RetailStoreDiscounts.Extension;

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
        [HttpPost]
        public async Task<IActionResult> GetBill(UserBillRequest userBillRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                UserBillResponse userBillResponse = await userBillService.GetBill(userBillRequest.userId, userBillRequest.productIdList);
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
}
