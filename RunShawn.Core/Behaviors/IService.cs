namespace RunShawn.Core.Behaviors
{
    public interface IService<T>
    {
        T GetById(int id);
        T Create(T obj);
        void Update(T obj);
        void Delete(string key);
    }
}
