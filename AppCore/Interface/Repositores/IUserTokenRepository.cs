using AppCore.Entities;
using System.Threading.Tasks;

namespace AppCore.Interface.Repositores
{
    public interface IUserTokenRepository : IBaseRepository<UserTokenEntity> 
    {
       Task<UserTokenEntity> Get(string nome, string password);
    }
}
