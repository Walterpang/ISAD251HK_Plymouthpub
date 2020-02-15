using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace PubNew.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        
        [Remote("IsAlreadySigned", "Register", HttpMethod = "POST", ErrorMessage = "Username already exists in database.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        
        [EmailAddress]
        [Remote("IsAlreadySigned", "Register", HttpMethod = "POST", ErrorMessage = "EmailId already exists in database.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
#pragma warning disable CS0618 // Type or member is obsolete
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
#pragma warning restore CS0618 // Type or member is obsolete
        public string ConfirmPassword { get; set; }
    }

}