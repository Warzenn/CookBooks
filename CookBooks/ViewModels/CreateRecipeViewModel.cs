using CookBook.Model;
using CookBook.Model.Enums;
using CookBooks.Model;

namespace CookBooks.ViewModels
{
    public class CreateRecipeViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? Rating { get; set; }
        public Degree? Degree { get; set; }
        public int Temperature { get; set; }
        public int? CookTime { get; set; }
        public RecipeCategory RecipeCategory { get; set; }
        public RecipeDifficultyLevel RecipeDifficultyLevel { get; set; }

        
        public List<Instructions>? Instructions { get; set; }
        public List<Ingredients>? Ingredients { get; set; }
    }
}
