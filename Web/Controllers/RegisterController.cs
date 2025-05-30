using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.User;
using Services.Interface;

namespace Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserRegisterModel user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }
            var result= await _userService.LoginAsync(user.UserName, user.Password);
            if(result != null)
            {
                // Login successful, redirect to home page or any other page
                return RedirectToAction("Index", "Home");
            }            
                
             ModelState.AddModelError("", "Invalid username or password.");
             return View(user);
              
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync(); // This clears the identity cookie
            return RedirectToAction("Login", "Register"); // Redirect to login or home
        }


    }
}
