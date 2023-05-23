using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using CookBooks.Model;

namespace CookBook.Model
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string? ProfileImage { get; set; }
        public List<Recipe>? Recipes { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
