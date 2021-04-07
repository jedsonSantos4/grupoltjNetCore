using AppCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCore.Interface.Repositores
{
    public interface IUserRepository: IBaseRepository<UserEntity> 
    {      
        Task<IEnumerable<UserEntity>> GetRegisterUsersAll();

        Task<UserEntity> GetRegisterUser(string id);

    }
}
