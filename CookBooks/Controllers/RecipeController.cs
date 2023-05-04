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
        private readonly IRecipeRepository _recipeRepository;
        private readonly IPhotoService _photoService;

        public RecipeController(IRecipeRepository recipeRepository, IPhotoService photoService)
        {

            _recipeRepository = recipeRepository;
            _photoService = photoService;
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
                var result = await _photoService.AddPhotoAsync(recipeVM.Image);
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
                    Temperature = recipeVM.Temperature,
                    Image = result.Url.ToString()
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

        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                ModelState.AddModelError("", "Error finding Recipe");
            }
            
            
            return View(recipe);    
        }
    }
}

