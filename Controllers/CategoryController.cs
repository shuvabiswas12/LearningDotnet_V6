using LearningDotnet_V6.Data;
using LearningDotnet_V6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create(Category category)
        {
            // Server side validation using "ModelState.IsValid"
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id.Equals(null) || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid && category != null)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName("Delete")]
        public IActionResult DeleteCategory(int id)
        {
            if (id.Equals(null) || id == 0)
            {
                return NotFound();
            }
            else
            {
                var category = _context.Categories.Find(id);
                if (category == null) { return NotFound(); }
                else
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                };
            }
        }
    }
}
