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

            //var users = new List<UserTokenEntity>
            //{
            //    new UserTokenEntity { Id = "1", Nome = "thaiz", Password = "jedson", Role = "gerente" },
            //    new UserTokenEntity { Id = "2", Nome = "jedson", Password = "jedson", Role = "default" }
            //};

            //return users.Where(x => 
            //                   x.Nome.ToLower() == nome.ToLower() && 
            //                   x.Password == x.Password).FirstOrDefault();


            var filter = Builders<UserEntity>.Filter.Eq(s => s.Email, email);
            return await Collection.Find(filter).FirstOrDefaultAsync();

        }

        public Task<UserEntity> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UserEntity>> GeAll() => await Collection.Find(_ => true).ToListAsync();
        
    }


}

