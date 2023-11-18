using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FIADatabase.Areas.FIAUsers.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Username may not contain spaces")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Username must be between 6 and 30 characters.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Username may not contain spaces")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 16 characters.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "You must confirm your password.")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
    }
}
    