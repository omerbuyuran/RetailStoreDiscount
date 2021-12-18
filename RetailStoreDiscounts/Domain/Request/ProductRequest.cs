using System.ComponentModel.DataAnnotations;

namespace RetailStoreDiscounts.Domain.Request
{
    public class ProductRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}
