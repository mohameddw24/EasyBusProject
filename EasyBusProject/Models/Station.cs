using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBus.Models
{
    
    [Table("Station")]
    public class Station
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? City { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set;}

        [InverseProperty("PickUp")]
        public virtual List<Trip>? TripsAsPickUp { get; set; }

        [InverseProperty("DropOff")]
        public virtual List<Trip>? TripsAsDropOff { get; set; }
    }

}
