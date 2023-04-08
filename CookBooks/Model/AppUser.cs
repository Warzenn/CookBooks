using System.ComponentModel.DataAnnotations;


namespace CookBook.Model
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? ProfileImage { get; set; }
        public ICollection<Recipe>? Recipes { get; set; }
        
    }
}
