using Microsoft.EntityFrameworkCore;
using RetailStoreDiscounts.Domain.Interfaces;
using RetailStoreDiscounts.Domain.Model;

namespace RetailStoreDiscounts.Domain.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(RetailStoreDiscountDBContext context) : base(context)
        {
        }

        public async Task AddProductAsync(Product product)
        {
           await context.Products.AddAsync(product);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await context.Products.FindAsync(productId);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task RemoveProductAsync(int productId)
        {
            //await callback mekanizması, metoddan cevap gelene kadar alt metoda geçmesini engelliyor
            var product = await GetProductByIdAsync(productId);
            context.Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
        }
    }
}
