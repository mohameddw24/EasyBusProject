using System.ComponentModel.DataAnnotations;

namespace EasyBusProject.ViewModels
{
    public class LoginUserVM
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
