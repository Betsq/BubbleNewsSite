using System.ComponentModel.DataAnnotations;

namespace BubbleNewsSite.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
