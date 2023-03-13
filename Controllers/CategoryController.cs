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
            IEnumerable<Category> categories = _context.Categories;
            return View(categories);
        }
    }
}
