using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must be the same")]
        public string ConfirmPassword { get; set; }
    }
}
