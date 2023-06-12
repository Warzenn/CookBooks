﻿using CookBook.Model;
using CookBook.Model.Enums;
using CookBooks.Interfaces;
using CookBooks.Model;
using CookBooks.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace CookBooks.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IPhotoService _photoService;
        private readonly UserManager<AppUser> _userManager;

        public RecipeController(IRecipeRepository recipeRepository, IPhotoService photoService, UserManager<AppUser> userManager)
        {

            _recipeRepository = recipeRepository;
            _photoService = photoService;
            _userManager = userManager;
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
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

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
                    Image = result.Url.ToString(),
                    Owner = user,
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
            if (recipe == null) return View("Error");
            var recipeVM = new EditRecipeViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                Rating = recipe.Rating,
                CookTime = recipe.CookTime,
                RecipeCategory = recipe.RecipeCategory,
                RecipeDifficultyLevel = recipe.RecipeDifficultyLevel,
                Degree = recipe.Degree,
                Temperature = recipe.Temperature,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions,
                URL = recipe.Image
            };
            return View(recipeVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditRecipeViewModel recipeVM, int id)
        {

                var recipe = await _recipeRepository.GetByIdAsync(id);

                if (recipe == null) return View("Error");
                var oldImage = recipe.Image;

                recipe.Name = recipeVM.Name;
                recipe.Description = recipeVM.Description;

                recipe.RecipeCategory = recipeVM.RecipeCategory;
                recipe.CookTime = recipeVM.CookTime;
                recipe.Temperature = recipeVM.Temperature;
                recipe.Degree = recipeVM.Degree;
                recipe.RecipeDifficultyLevel = recipeVM.RecipeDifficultyLevel;
                recipe.Ingredients = recipeVM.Ingredients;
                recipe.Instructions = recipeVM.Instructions;

                if(recipeVM.Image != null)
                {
                await _photoService.DeletePhotoAsync(oldImage);
                var result = await _photoService.AddPhotoAsync(recipeVM.Image);
                recipe.Image = result.Url.ToString();
                }

                _recipeRepository.Update(recipe);

                return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var recipeDetails = await _recipeRepository.GetByIdAsync(id);
            if (recipeDetails == null) return View("Error");
            return View(recipeDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipeToDelete = await _recipeRepository.GetByIdAsync(id);
            if (recipeToDelete == null) return View("Error");

            await _photoService.DeletePhotoAsync(recipeToDelete.Image);

            _recipeRepository.Delete(recipeToDelete);
            return RedirectToAction("Index");
        }
    }
}
