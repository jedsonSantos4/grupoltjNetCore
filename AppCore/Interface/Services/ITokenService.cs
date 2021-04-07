using AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interface.Services
{
    public interface ITokenService : IBaseService<UserTokenEntity>
    {
        Task<ValidResult<UserTokenEntity>> Get(string nome, string password);
    }
}
