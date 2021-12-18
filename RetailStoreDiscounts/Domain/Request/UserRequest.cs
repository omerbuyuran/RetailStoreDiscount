using System.ComponentModel.DataAnnotations;

namespace RetailStoreDiscounts.Domain.Request
{
    public class UserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string? Type { get; set; }
    }
}
