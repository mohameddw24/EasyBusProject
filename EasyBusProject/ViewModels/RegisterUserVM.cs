using System.ComponentModel.DataAnnotations;

namespace EasyBusProject.ViewModels
{
    public class RegisterUserVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
