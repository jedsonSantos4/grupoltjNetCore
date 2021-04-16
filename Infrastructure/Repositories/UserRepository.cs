using AppCore.Entities;
using AppCore.Interface.Repositores;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(IMongoClient mongoClient,
            IClientSessionHandle clientSessionHandle)
            : base(mongoClient, clientSessionHandle, "users")
        {
        }

        public async Task<UserEntity> Get(string email, string password)
        {            
            var filter = Builders<UserEntity>.Filter.Eq(s => s.Email, email);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

    }


}

