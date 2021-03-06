﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BubbleNewsSite.ViewModels
{
    public class CreateUserViewModel
    {
        [Remote(action: "CheckEmail", controller: "Account", ErrorMessage = "Email is busy")]
        public string Email { get; set; }
        public string Password { get; set; }

        [Remote(action: "CheckName", controller: "Account", ErrorMessage = "Username is busy")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The length must be between 1 and 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The length must be between 1 and 20 characters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Avatar")]
        public IFormFile Avatar { get; set; }
    }
}
