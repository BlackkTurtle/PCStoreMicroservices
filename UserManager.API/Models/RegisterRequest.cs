using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using UserDataAccess.Validations;

namespace UserManager.API.Models
{
    public class RegisterRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [OnlyAlphabetsValidator(ErrorMessage = "Do not use numbers in your First Name")]
        public string FirstName { get; set; } = null!;
        [Required]
        [OnlyAlphabetsValidator(ErrorMessage = "Do not use numbers in your Last Name")]
        public string LastName { get; set; } = null!;
        [OnlyAlphabetsValidator(ErrorMessage = "Do not use numbers in your Father Name")]
        public string? Father { get; set; }
        [Required]
        [RegularExpression(@"^\+?3?8?(0\d{9})$")]
        public string Phone { get; set; } = null!;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required, DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
