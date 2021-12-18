namespace RetailStoreDiscounts.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly RetailStoreDiscountDBContext context;
        public BaseRepository(RetailStoreDiscountDBContext context)
        {
            this.context = context;
        }
    }
}
