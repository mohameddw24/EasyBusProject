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
        public virtual Trip Trip { get; set; } = null!;

        public DateTime Date { get; set; }

        [NotMapped]
        public int TotalCapacity => (int)Trip.Bus.Seats;

        [NotMapped]
        public int ReservedSeats => UserSchedules.Count(us => us.ScheduleId == Id);

        [NotMapped]
        public int AvailableSeats => TotalCapacity - ReservedSeats;

        public ICollection<UserSchedule> UserSchedules { get; set; } = null!;
    }
}
