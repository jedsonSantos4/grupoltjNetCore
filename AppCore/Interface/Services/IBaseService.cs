using AppCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCore.Interface.Services
{
    public interface IBaseService<T>
    {
        Task<ValidResult<bool>> UpdateAsync(T obj);
        Task<ValidResult<bool>> InsertAsync(T obj);
        Task<ValidResult<bool>> DeleteAsync(string id);
        Task<T> Get(string id);
        Task<ValidResult<List<T>>> GetAll();
    }
}
