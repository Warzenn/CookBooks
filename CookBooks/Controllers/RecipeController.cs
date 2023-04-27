using CookBook.Model;
using CookBook.Model.Enums;
using CookBooks.Interfaces;
using CookBooks.Model;
using CookBooks.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CookBooks.Controllers
{
    public class RecipeController : Controller
    {
        List<CreateRecipeViewModel> vm = new List<CreateRecipeViewModel>();

        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeViewModel recipeVM)
        {
        
            if (ModelState.IsValid)
            {
                var recipe = new Recipe
                {
                    Ingredients = recipeVM.Ingredients,
                    Instructions = recipeVM.Instructions,
                    Name = recipeVM.Name,
                    Description = recipeVM.Description,
                    Rating = recipeVM.Rating,
                    CookTime = recipeVM.CookTime,
                    RecipeCategory = recipeVM.RecipeCategory,
                    Degree = recipeVM.Degree,
                    RecipeDifficultyLevel = recipeVM.RecipeDifficultyLevel,
                    Temperature = recipeVM.Temperature
   
                };
       
                _recipeRepository.Add(recipe);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error creating Recipe");
            }
            return View(recipeVM);
        }
    }
}

