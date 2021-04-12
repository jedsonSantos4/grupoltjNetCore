using AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interface.Services
{
    public interface IUserService : IBaseService<UserEntity>
    {
        Task<ValidResult<UserEntity>> Auth(string nome, string password);
        Task<ValidResult<UserEntity>> Get(string id);
        //Task<ValidResult<UserEntity>> GetAll();
        Task<ValidResult<List<UserEntity>>> GetAll();
    }
}
