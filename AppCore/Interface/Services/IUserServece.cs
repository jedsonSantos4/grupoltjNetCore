using AppCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCore.Interface.Services
{
    public interface IUserServece :IBaseService<UserEntity>
    {
        Task<ValidResult<List<UserEntity>>> GetRegisterUsersAll();

        Task<ValidResult<UserEntity>> GetRegisterUser(string id);

    }
}
