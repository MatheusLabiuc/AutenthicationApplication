using System.ComponentModel.DataAnnotations;

namespace AspNetCoreAuth.ViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "As duas senhas não são iguais")]
        public string ConfirmPassword { get; set; }
    }
}
