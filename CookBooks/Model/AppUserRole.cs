using CookBook.Model;
using Microsoft.AspNetCore.Identity;

namespace CookBooks.Model
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}