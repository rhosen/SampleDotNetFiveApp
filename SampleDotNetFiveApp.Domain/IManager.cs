using System.Collections.Generic;

namespace SampleDotNetFiveApp.Data.Domain
{
    public interface IManager<T> where T: class
    {
        List<T> GetAll();
        T Get(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(int id);
    }
}
