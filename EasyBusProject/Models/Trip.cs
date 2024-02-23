using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBus.Models
{
    [Table("Trip")]
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EnumDataType(typeof(WeekDays))]
        public List<WeekDays>? AvailableDays { get; set; }

        [ForeignKey("Bus")]
        public int BusId { get; set; }
        public Bus Bus { get; set; } = null!;

        [Required]
        [DataType(DataType.Time)]
        public TimeOnly Time { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be a positive integer.")]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be a positive integer.")]
        public int Duration { get; set; }

        [Display(Name = "Pick-up Location")]
        [ForeignKey("PickUp")]
        public int? PickUpID { get; set; }

        [Display(Name = "Drop-off Location")]
        [ForeignKey("DropOff")]
        public int? DropOffID { get; set; }

        //Navigation Prosperities
        public Station? PickUp { get; set; }
        public Station? DropOff { get; set; }

    }

    public enum WeekDays
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }

}
