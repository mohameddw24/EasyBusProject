using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EasyBus.Models
{
    public class User : IdentityUser<int>
    {
        public string ClientName { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public virtual ICollection<UserSchedule>? UserSchedules { get; set; }
    }
}
