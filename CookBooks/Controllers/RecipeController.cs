using CookBook.Model;
using CookBooks.Data;
using CookBooks.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CookBooks.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(ApplicationDbContext context, IRecipeRepository recipeRepository)
        {
            _context = context;
            _recipeRepository = recipeRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Recipe> recipe = await _recipeRepository.GetAll();
            return View(recipe);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Recipe recipe = await _recipeRepository.GetByIdAsync(id);
            return View(recipe);
        }
    }
}
