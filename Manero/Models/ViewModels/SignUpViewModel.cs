using Manero.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Manero.Models.ViewModels
{
    public class SignUpViewModel
    {
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "First name must start with a capital letter and no special characters allowed, e.g. Test")]
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "FIRST NAME")]
        public string FirstName { get; set; } = null!;

        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Last name must start with a capital letter and no special characters allowed, e.g. Test")]
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "LAST NAME")]
        public string LastName { get; set; } = null!;

        [RegularExpression("^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$", ErrorMessage = "It must be a valid email, e.g. test@domain.com")]
        [Required(ErrorMessage = "Email Address is required")]
        [Display(Name = "EMAIL ADDRESS")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "PASSWORD")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [Required(ErrorMessage = "Confirming Password is required")]
        [Display(Name = "CONFIRM PASSWORD")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        public static implicit operator AppUser(SignUpViewModel model)
        {
            return new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName= model.Email
            };
        }
    }
}
