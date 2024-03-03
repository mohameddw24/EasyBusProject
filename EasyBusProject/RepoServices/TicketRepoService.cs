using EasyBus.Models;
using EasyBusProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyBusProject.RepoServices
{
    public class TicketRepoService(MainDbContext context) : IRepository<Ticket>
    {
        private readonly MainDbContext context = context;
        public void Add(Ticket entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public Ticket Details(int id)
        {
            return context.Tickets.Include(t => t.User).Where(s => s.Id == id).FirstOrDefault(); 
        }

        public List<Ticket> GetAll()
        {
            return context.Tickets.ToList();
        }

        public void Remove(Ticket entity)
        {
            context.Tickets.Remove(entity);
            context.SaveChanges();
        }

        public void Update(Ticket entity)
        {
            context.Tickets.Update(entity);
            context.SaveChanges();
        }
    }
}
