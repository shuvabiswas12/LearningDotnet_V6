using LearningDotnet_V6.Data;
using LearningDotnet_V6.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningDotnet_V6.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            // We are not used List<> here because List<> returns null if object is empty.
            // But IEnumerable<> does not returns empty or null objects.
            IEnumerable<Category> categories = _context.Categories;
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category) {
            // Server side validation using "ModelState.IsValid"
           if (ModelState.IsValid) {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           return View();
        }
    }
}
