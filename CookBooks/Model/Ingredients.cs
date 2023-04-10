

using CookBook.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBooks.Model
{
    public class Ingredients
    {

        public int Id { get; set; }
        public string? Ingredient { get; set; }


    }
}
