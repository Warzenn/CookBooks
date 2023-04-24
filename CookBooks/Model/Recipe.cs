using System.ComponentModel.DataAnnotations;
using CookBook.Model.Enums;
using CookBooks.Model;

namespace CookBook.Model
{
    public class Recipe
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? Rating { get; set; }
        public Degree? Degree { get; set; }
        [Required]
        public int Temperature { get; set; }
        [Required(ErrorMessage = "Temperature is required.")]
        public int? CookTime { get; set; }
        [Required(ErrorMessage = "CookTime is required.")]

        public RecipeCategory RecipeCategory { get; set; }
        public RecipeDifficultyLevel RecipeDifficultyLevel { get; set; }

     
        public AppUser? Owner { get; set; }

        [Required]
        public List<Instructions> Instructions { get; set; }

        [Required]
        public List<Ingredients> Ingredients { get; set; }


    }
}
