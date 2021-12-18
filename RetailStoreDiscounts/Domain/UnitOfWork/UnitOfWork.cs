using RetailStoreDiscounts.Domain.Interfaces;
using RetailStoreDiscounts.Domain.Repositories;

namespace RetailStoreDiscounts.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RetailStoreDiscountDBContext context;
        public UnitOfWork(RetailStoreDiscountDBContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
