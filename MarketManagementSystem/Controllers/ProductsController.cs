using MarketManagementSystem.Models;
using MarketManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MarketManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductRepository.GetProducts(loadCategory: true);
            return View(products);
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (product != null)
            {
                ProductRepository.UpdateProduct(product.ProductId, product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        public IActionResult Add(Product product)
        {

            return View(product);
        }
    }
}
