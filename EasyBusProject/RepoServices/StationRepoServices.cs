using EasyBus.Models;

namespace EasyBusProject.RepoServices
{
    public class StationRepoServices(MainDbContext context) : IRepository<Station>
    {
        public MainDbContext Context { get; } = context;

        public void Add(Station entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public Station Details(int id)
        {
            var station = Context.Stations.Where(s => s.Id == id).FirstOrDefault();
            if (station != null)
                return station;
            return new Station();
        }

        public List<Station> GetAll()
        {
            return Context.Stations.ToList();
        }

        public void Remove(Station entity)
        {
            Context.Stations.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(Station entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
    }
}
