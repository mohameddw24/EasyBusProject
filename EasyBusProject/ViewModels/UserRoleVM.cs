using System.ComponentModel.DataAnnotations;

namespace EasyBusProject.ViewModels
{
    public class UserRoleVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public bool IsAdmin { get; set; }



    }
}
