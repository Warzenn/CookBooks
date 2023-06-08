

using System.ComponentModel.DataAnnotations;

namespace CookBooks.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password is required")]
        public string confirmPassword { get; set; }
    }
}
