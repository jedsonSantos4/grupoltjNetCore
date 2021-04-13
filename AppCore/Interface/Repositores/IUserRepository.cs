using AppCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCore.Interface.Repositores
{
    public interface IUserRepository : IBaseRepository<UserEntity> 
    {
       Task<UserEntity> Get(string nome, string password);
        Task<UserEntity> Get(string id);        
        Task<List<UserEntity>> GeAll();
    }
}
