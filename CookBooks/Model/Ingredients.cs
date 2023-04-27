using CookBook.Model;
using System.ComponentModel.DataAnnotations;

namespace CookBooks.Model
{
    public class Ingredients
    {
        
        public int Id { get; set; }
        [Required]
        public string Ingredient { get; set; }

        public Recipe? Recipe { get; set; }


    }
}
