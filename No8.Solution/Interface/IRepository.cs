using System.Collections.Generic;

namespace No8.Solution.Interface
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        IEnumerable<T> GetAll();
    }
}
