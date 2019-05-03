using System.Collections.Generic;

namespace RunShawn.Core.Base
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll(bool deleted = false);
        T GetById(long id);

        T Create(T obj, string userId);

        T Update(T obj, string userId);

        void Delete(long id, string userId);
    }
}