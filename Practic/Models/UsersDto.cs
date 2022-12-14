using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class UsersDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "این ایتم اجباری است")]
        public string Name { get; set; }
        [Required(ErrorMessage = "این ایتم اجباری است")]

        public string NationalCode { get; set; }
        [Required(ErrorMessage = "این ایتم اجباری است")]

        public string Username { get; set; }
        [Required(ErrorMessage = "این ایتم اجباری است")]
        public string Password { get; set; }
        [Required(ErrorMessage = "این ایتم اجباری است")]
        [Compare(nameof(Password), ErrorMessage = "پشورد ها شبیه به هم نیستند")]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "این ایتم اجباری است")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
