using EasyBus.Models;
using System.Diagnostics;
using System.Security.Principal;

namespace EasyBusProject.RepoServices
{
    public class UserScheduleRepoServices(MainDbContext context) : IRepository<UserSchedule>
    {
        private MainDbContext _context { get; } = context;

        public void Add(UserSchedule entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public UserSchedule Details(int id)
        {
            return _context.UserSchedules.Find(id);
        }

        public List<UserSchedule> GetAll()
        {
            return _context.UserSchedules.ToList();
        }

        public void Remove(UserSchedule entity)
        {
            _context.UserSchedules.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(UserSchedule entity)
        {
            _context.UserSchedules.Update(entity);
            _context.SaveChanges();
        }
        public int GetAvailableSeats(int id)
        {
            Debug.WriteLine(_context.UserSchedules.Where(us => us.ScheduleId == id).Sum(us => us.NumOfSeats));
            return _context.UserSchedules.Where(us => us.ScheduleId == id).Sum(us => us.NumOfSeats);
        }
    }
}
