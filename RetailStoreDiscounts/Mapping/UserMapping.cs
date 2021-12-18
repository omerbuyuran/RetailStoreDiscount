using AutoMapper;
using RetailStoreDiscounts.Domain.Model;
using RetailStoreDiscounts.Domain.Request;

namespace RetailStoreDiscounts.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserRequest>();
        }
    }
}
