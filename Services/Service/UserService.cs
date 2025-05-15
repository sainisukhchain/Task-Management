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

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
              _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterAsync(string username,string password)
        {
            var user = new ApplicationUser();
            user.UserName = username;
            user.Email = username;
            return await _userManager.CreateAsync(user,password);

        }

        public async Task<ApplicationUser> LoginAsync(string username,string password)
        {
            var user= await _userManager.FindByEmailAsync(username);
            if (user != null && await _userManager.CheckPasswordAsync(user, password)) 
            {
                return user;
            }
            return null;
        }
    }
}
