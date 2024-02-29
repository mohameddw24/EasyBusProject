using System.ComponentModel.DataAnnotations;

namespace EasyBusProject.ViewModels
{
    public class TicketViewModel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }
        
        [DataType(DataType.Time)]
        public TimeOnly Time { get; set; }

        public string BusName { get; set; }
        public int Price { get; set; }
        public string StartFrom { get; set; }
        public string Destination { get; set; }
        public int NumOfSeatsOfUser { get; set; }
    }
}
