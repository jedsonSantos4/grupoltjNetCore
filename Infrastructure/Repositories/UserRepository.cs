using AppCore.Entities;
using AppCore.Interface.Repositores;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {               

        public UserRepository(IMongoClient mongoClient,
            IClientSessionHandle clientSessionHandle) 
            : base(mongoClient, clientSessionHandle, "User")
        {
        }    


        public async Task<UserEntity> GetRegisterUser(string id)
        {
            var filter = Builders<UserEntity>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();            
        }

        public async Task<IEnumerable<UserEntity>> GetRegisterUsersAll()
        {
           return await Collection.AsQueryable().ToListAsync();            
        }
    }
}
