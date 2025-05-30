using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Services.Interface;

namespace Services.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterAsync(string username, string password)
        {
            var user = new ApplicationUser();
            user.UserName = username;
            user.Email = username;
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                string role = "Admin";
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }

                // Assign role to user
                await _userManager.AddToRoleAsync(user, role);
            }
            return result;
        }

        public async Task<ApplicationUser> LoginAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(username);
                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {
                    return user;
                }
            }
            return null;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync(); // This clears the identity cookie
        }
    }
}
