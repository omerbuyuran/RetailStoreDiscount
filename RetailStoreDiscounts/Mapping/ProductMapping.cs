using AutoMapper;
using RetailStoreDiscounts.Domain.Model;
using RetailStoreDiscounts.Domain.Request;

namespace RetailStoreDiscounts.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductRequest,Product>();
            CreateMap<Product,ProductRequest>();
        }
    }
}
