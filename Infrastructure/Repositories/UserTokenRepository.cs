using AppCore.Entities;
using AppCore.Interface.Repositores;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class UserTokenRepository : BaseRepository<UserTokenEntity>, IUserTokenRepository
    {
        public UserTokenRepository(IMongoClient mongoClient,
            IClientSessionHandle clientSessionHandle)
            : base(mongoClient, clientSessionHandle, "users")
        {
        }

        public async Task<UserTokenEntity> Get(string nome, string password)
        {

            //var users = new List<UserTokenEntity>
            //{
            //    new UserTokenEntity { Id = "1", Nome = "thaiz", Password = "jedson", Role = "gerente" },
            //    new UserTokenEntity { Id = "2", Nome = "jedson", Password = "jedson", Role = "default" }
            //};

            //return users.Where(x => 
            //                   x.Nome.ToLower() == nome.ToLower() && 
            //                   x.Password == x.Password).FirstOrDefault();


            var filter = Builders<UserTokenEntity>.Filter.Eq(s => s.nome, nome);
            return await Collection.Find(filter).FirstOrDefaultAsync();

        }

    }


}

