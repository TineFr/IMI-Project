using System;

namespace Imi.Project.Mobile.Core.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
