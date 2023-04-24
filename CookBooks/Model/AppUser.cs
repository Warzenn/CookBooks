using System.ComponentModel.DataAnnotations;


namespace CookBook.Model
{
    public class AppUser
    {

     
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? ProfileImage { get; set; }
        public List<Recipe>? Recipes { get; set; }

    }
}
