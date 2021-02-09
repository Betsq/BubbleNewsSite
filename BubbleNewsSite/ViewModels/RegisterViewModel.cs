using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BubbleNewsSite.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
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

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "CheckEmail", controller: "Account", ErrorMessage = "Email is busy")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Field {0} must have at least {2} and maximum {1} characters.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }

        [Display(Name ="Avatar")]
        public IFormFile Avatar { get; set; }
    }
}
