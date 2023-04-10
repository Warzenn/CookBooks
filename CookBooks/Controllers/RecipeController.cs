using CookBook.Model;
using CookBooks.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CookBooks.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Recipe = _context.Recipes.ToList();
            return View(Recipe);
        }

        public IActionResult Detail(int id)
        {
            Recipe recipe = _context.Recipes.Include(i => i.Instructions).Include(j => j.Ingredients).FirstOrDefault(c => c.RecipeId == id);
            return View(recipe);
        }
    }
}
