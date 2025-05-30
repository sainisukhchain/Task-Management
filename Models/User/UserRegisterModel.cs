using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        //[EmailAddress(ErrorMessage = "Invalid email format.")]
        //public string Email { get; set; }

        public bool IsRemember { get; set; }
    }
}
