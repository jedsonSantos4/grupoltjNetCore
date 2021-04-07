using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interface.Repositores
{
    public interface IBaseRepository<T>
    {
        Task UpdateAsync(T obj);
        Task InsertAsync(T obj);
        Task DeleteAsync(string id);
      
    }
}
