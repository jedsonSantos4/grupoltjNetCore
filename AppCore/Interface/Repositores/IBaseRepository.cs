using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCore.Interface.Repositores
{
    public interface IBaseRepository<T>
    {
        Task UpdateAsync(T obj);
        Task InsertAsync(T obj);
        Task DeleteAsync(string id);
        Task<T> Get(string id);
        Task<IEnumerable<T>> GeAll();

    }
}
