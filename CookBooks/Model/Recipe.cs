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
        public string ?Name { get; set; }
        public string ?Description { get; set; }
        public string ?Image { get; set; }
        public int Rating { get; set; }
        public RecipeCategory Category { get; set; }
        public RecipeDifficultyLevel RecipeDifficultyLevel { get; set; }
        [ForeignKey("AppUser")]
        public AppUser? Owner { get; set;}
        [ForeignKey("InstructionsId")]
        public ICollection<Instructions> ?Instructions { get; set; }
        [ForeignKey("IngredientsId")]
        public ICollection<Ingredients> ?Ingredients { get; set; }



    }
}
