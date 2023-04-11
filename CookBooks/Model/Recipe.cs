using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Markup;
using CookBook.Model.Enums;
using CookBooks.Model;

namespace CookBook.Model
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? Rating { get; set; }
        public Degree? Degree { get; set; }
        public int? Temperature { get; set; }
        public string? CookTime { get; set; }
        
        public RecipeCategory RecipeCategory { get; set; }
        public RecipeDifficultyLevel RecipeDifficultyLevel { get; set; }
        [ForeignKey("AppUser")]
        public AppUser? Owner { get; set; }
        [ForeignKey("InstructionsId")]
        public ICollection<Instructions>? Instructions { get; set; }
        [ForeignKey("IngredientsId")]
        public ICollection<Ingredients>? Ingredients { get; set; }


    }
}
