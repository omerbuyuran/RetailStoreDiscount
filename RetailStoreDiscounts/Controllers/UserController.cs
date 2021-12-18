using AutoMapper;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            UserListResponse userListResponse = await userService.ListAsync();
            if (userListResponse.Success)
            {
                return Ok(userListResponse.UserList);
            }
            else
            {
                return BadRequest(userListResponse.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            UserResponse userResponse = await userService.GetUserByIdAsync(id);
            if (userResponse.Success)
            {
                return Ok(userResponse.User);
            }
            else
            {
                return BadRequest(userResponse.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Adduser(UserRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                User user = mapper.Map<UserRequest, User>(userRequest);
                UserResponse userResponse = await userService.AddUser(user);
                if (userResponse.Success)
                {
                    return Ok(userResponse.User);
                }
                else
                {
                    return BadRequest(userResponse.Message);
                }
            }
        }
        [HttpPut]
        public async Task<IActionResult> Updateuser(UserRequest userRequest, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                User user = mapper.Map<UserRequest, User>(userRequest);
                UserResponse userResponse = await userService.UpdateUser(user, id);
                if (userResponse.Success)
                {
                    return Ok(userResponse.User);
                }
                else
                {
                    return BadRequest(userResponse.Message);
                }
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Removeuser(int id)
        {
            UserResponse response = await userService.RemoveUser(id);
            if (response.Success)
            {
                return Ok(response.User);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
