﻿using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace iTransition.Forms.Web.Models
{
    public class RegistrationModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Display(Name = "User name")]
        public string UserName { get; set; }

        [Required, Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required, StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string? ReturnUrl { get; set; }
        public IList<AuthenticationScheme>? ExternalLogins { get; set; }
    }
}
