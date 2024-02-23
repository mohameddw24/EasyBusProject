using EasyBus.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyBusProject.RepoServices
{
    public class TripsRepoServices(MainDbContext context) : IRepository<Trip>
    {
        private readonly MainDbContext context = context;

        public void Add(Trip entity)
        {
            context.Add<Trip>(entity);
            context.SaveChanges();
        }

        public Trip Details(int id)
        {
            var trip = context.Trips.Where(t => t.Id == id).FirstOrDefault();
            if (trip != null) 
                return trip;

            return new Trip();
        }

        public List<Trip> GetAll()
        {
            return context.Trips.Include(t => t.Bus).Include(s => s.DropOff).Include(s => s.PickUp).ToList();
        }

        public void Remove(Trip entity)
        {
            context.Trips.Remove(entity);
            context.SaveChanges();
        }

        public void Update(Trip entity)
        {
            context.Trips.Update(entity);
            context.SaveChanges();
        }
    }
}
