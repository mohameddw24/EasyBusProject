namespace EasyBusProject.RepoServices
{
    public interface IRepository<Entity> where Entity : class
    {
        public void Add(Entity entity);

        public List<Entity> GetAll();

        public Entity Details(int id);

        public void Update(Entity entity);

        public void Remove(Entity entity);
    }
}
