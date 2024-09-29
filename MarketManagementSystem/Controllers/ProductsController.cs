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


        public IActionResult Add()
        {
            var productViewModel = new ProductViewModel()
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.AddProduct(productViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel);
        }

        public IActionResult Edit(int id)
        {
            var productViewModel = new ProductViewModel()
            {
                Product = ProductRepository.GetProductById(id) ??new Product(),
                Categories = CategoriesRepository.GetCategories()
            };
            return View(productViewModel);
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
    }
}
