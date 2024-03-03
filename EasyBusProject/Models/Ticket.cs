using EasyBus.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBusProject.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeOnly Time { get; set; }

        [Required(ErrorMessage = "Number of seats is not Valid !")]
        public int NumOfAvailSeats { get; set; }

        [Required(ErrorMessage = "Bus name is required.")]
        public string BusName { get; set; }

        public int Price { get; set; }

        [Required(ErrorMessage = "Start location is required.")]
        public string StartFrom { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        public string Destination { get; set; }

        
        //[Range(1,52,ErrorMessage ="Please choose seats")]
        public int NumOfSeatsOfUser { get; set; }

        public int TotalCapacity { get; set; }

        public string? Seats { get; set; }
    }
}
