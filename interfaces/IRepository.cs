namespace CRUDBirds
{
    public interface IRepository<T>
    {
        List<T> Items();
        T ReturnById(int id);
        void Add(T entity);
        void Remove(int id);
        void Update(int id, T entity);
        int NextId();
    }
}