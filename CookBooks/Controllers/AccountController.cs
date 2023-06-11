using Azure;
using CookBook.Model;
using CookBooks.Data;
using CookBooks.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CookBooks.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;



        public AccountController(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if (user != null)
            {
                var passwordcheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);

                if (passwordcheck)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Recipe");
                    }
                }
                ModelState.AddModelError("", "You have entered wrong Password");
                return View(loginViewModel);
            }
            ModelState.AddModelError("", "You have entered either the Username and/or Password incorrectly");
            return View(loginViewModel);

        }

        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);

            if (user != null)
            {
                ModelState.AddModelError("", "User with that email already exist");
                return View(registerVM);
            }

            var newUser = new AppUser
            {
                UserName = registerVM.ConfirmPassword,

            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "user");
            }

            return RedirectToAction("Recipe","Index");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Recipe");
        }
    }
}
