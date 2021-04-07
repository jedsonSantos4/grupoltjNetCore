using AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interface.Services
{
    public interface IBaseService<T>
    {
        Task<ValidResult<bool>> UpdateAsync(T obj);
        Task<ValidResult<bool>> InsertAsync(T obj);
        Task<ValidResult<bool>> DeleteAsync(string id);
    }
}
