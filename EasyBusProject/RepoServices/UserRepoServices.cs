using EasyBus.Models;

namespace EasyBusProject.RepoServices
{
    public class UserRepoServices(MainDbContext context) : IRepository<User>
    {
        public MainDbContext Context { get; } = context;

        public void Add(User entity)
        {
            Context.Users.Add(entity);
            Context.SaveChanges();
        }

        public User Details(int id)
        {
            var user = Context.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
                return user;
            return new User();
        }

        public List<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public void Remove(User entity)
        {
            Context.Users.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(User entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
    }
}
