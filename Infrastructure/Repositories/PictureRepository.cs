using AppCore.Entities;
using AppCore.Interface.Repositores;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class PictureRepository : BaseRepository<PictureEntity>, IPictureRepository
    {
        public PictureRepository(IMongoClient mongoClient,
          IClientSessionHandle clientSessionHandle)
          : base(mongoClient, clientSessionHandle, "picture")
        {
        }

    }
}
