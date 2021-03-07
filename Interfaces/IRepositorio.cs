using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T getById(int id);
         void Insert(T entity);
         void Remove(int id);
         void Update(int id, T entity);
         int NextId();
    }
}