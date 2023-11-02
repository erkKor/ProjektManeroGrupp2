using Manero.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Manero.Models.ViewModels
{
    public class SignInViewModel
    {
        [RegularExpression("^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$", ErrorMessage = "It must be a valid email, e.g. test@domain.com")]
        [Required(ErrorMessage = "Email Address is required")]
        [Display(Name = "EMAIL")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "PASSWORD")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
