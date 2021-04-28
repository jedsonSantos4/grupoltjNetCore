using Amazon.S3;
using Amazon.S3.Model;
using AppCore.Entities;
using System.IO;
using System.Threading.Tasks;

namespace AppCore.Interface.Services
{
    public interface IPictureService : IBaseService<PictureEntity>
    {
        Task<ValidResult<bool>> AWSInsertAsync(PutObjectRequest put, IAmazonS3 s3, long sizeImg, string type);
        Task<ValidResult<bool>> AWSDeleteAsync(string imgName, IAmazonS3 s3);
        //Task<Stream> AWSGetAsync(string imgName, IAmazonS3 s3);

    }
}
