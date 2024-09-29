using MarketManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketManagementSystem.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }
        public IActionResult Edit([FromRoute] int? id)
        {
            ViewBag.Action = "edit";

            Category category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";

            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm]Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Delete(int categoryId)
        {

            CategoriesRepository.DeleteCategory(categoryId);
            return RedirectToAction(nameof(Index));
        }

    }
}
