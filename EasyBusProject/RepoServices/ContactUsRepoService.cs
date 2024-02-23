using EasyBus.Models;
using EasyBusProject.Models;

namespace EasyBusProject.RepoServices
{
    public class ContactUsRepoService(MainDbContext context) : IRepository<ContactUs>
    {
        private readonly MainDbContext Context = context;

        public void Add(ContactUs entity)
        {
            Context.ContactUs.Add(entity);
            Context.SaveChanges();
        }

        public ContactUs Details(int id)
        {
            return Context.ContactUs.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<ContactUs> GetAll()
        {
            return Context.ContactUs.ToList();
        }

        public void Remove(ContactUs entity)
        {
            Context.ContactUs.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(ContactUs entity)
        {
            Context.ContactUs.Update(entity);
            Context.SaveChanges();
        }
    }
}
