using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace EasyBus.Models
{
    [Table("Schedule")]
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Trip")]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }

        [NotMapped]
        public int TotalCapacity => (int)Trip.Bus.Seats;

        [NotMapped]
        public int ReservedSeats => UserSchedules.Where(us => us.ScheduleId == Id).Sum(us => us.NumOfSeats);

        [NotMapped]
        public int AvailableSeats => TotalCapacity - ReservedSeats;

        public int AvailableSeatsInTrip { get; set; }

        public string NumOfSeatsReserved { get; set; } = "";

        public ICollection<UserSchedule> UserSchedules { get; set; }
        
    }
}
