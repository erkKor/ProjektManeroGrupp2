using Manero.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Manero.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "FIRST NAME")]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "LAST NAME")]
        public string LastName { get; set; } = null!;


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

        public static implicit operator User(SignUpViewModel model)
        {
            return new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName= model.Email
            };
        }
    }
}
