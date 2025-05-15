using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Services.Interface
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterAsync(string username, string password);
        Task<ApplicationUser> LoginAsync(string username, string password);
    }
}
