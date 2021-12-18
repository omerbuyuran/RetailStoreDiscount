using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
namespace RetailStoreDiscounts.Extension
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors).Select(x => x.ErrorMessage).ToList();
        }
    }
}
