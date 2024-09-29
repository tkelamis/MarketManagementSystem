using MarketManagementSystem.Models;

namespace MarketManagementSystem.ViewModels
{
    public class CategoryProductViewModel
    {
        public Product Product { get; set; } = new Product();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

    }
}
