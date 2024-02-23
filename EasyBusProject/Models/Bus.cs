using EasyBusProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBus.Models
{
    [Table("Bus")]
    public class Bus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EnumDataType(typeof(SeatCount))]
        public SeatCount Seats { get; set; }

        [Required]
        [EnumDataType(typeof(Category))]
        public Category Category { get; set; }

        [Required]
        [StringLength(50)]
        public string? Model { get; set; }
        public virtual ICollection<Trip>? Trips { get; set; }

    }

    public enum SeatCount { Small = 14, Medium = 32, Large = 52 }
    public enum Category { Economy, Standard, Premium }
}