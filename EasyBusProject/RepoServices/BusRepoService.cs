using EasyBus.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyBusProject.RepoServices
{
    public class BusRepoService(MainDbContext context) : IRepository<Bus>
    {
        private readonly MainDbContext context = context;

        public void Add(Bus entity)
        {
            context.Buses.Add(entity);
            context.SaveChanges();
        }

        public Bus Details(int id)
        {
            var bus = context.Buses.Include(b => b.Trips).Where(b => b.Id == id).FirstOrDefault();
            if(bus != null)
                return bus;
            return new Bus();
        }

        public List<Bus> GetAll()
        {
            return context.Buses.ToList();
        }

        public void Remove(Bus entity)
        {
            context.Buses.Remove(entity);
            context.SaveChanges();
        }

        public void Update(Bus entity)
        {
            context.Buses.Update(entity);
            context.SaveChanges();
        }
    }
}
