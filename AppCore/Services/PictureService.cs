using Amazon.S3;
using Amazon.S3.Model;
using AppCore.Entities;
using AppCore.Helpers;
using AppCore.Interface.Repositores;
using AppCore.Interface.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _picture;
        public PictureService(IPictureRepository pictureRepository)
        {
            _picture = pictureRepository;
        }      

        public async Task<ValidResult<bool>> AWSDeleteAsync(string imgName, IAmazonS3 s3)
        {
            var result = new ValidResult<bool>();
            try
            {
                var resqt = new DeleteObjectRequest()
                {
                    BucketName = "ltjuploadimage",
                    Key = imgName
                };

                var resp = await s3.DeleteObjectAsync(resqt);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

   

        public async Task<ValidResult<bool>> AWSInsertAsync(PutObjectRequest put, IAmazonS3 s3, long sizeImg, string type)
        {


            var result = new ValidResult<bool>();
            string[] allowerMimes = { "image/jpeg", "image/pjpeg", "image/png", "image/gif" };
            var limite = (2 * 1024 * 1024);
            if (string.IsNullOrEmpty(put.Key.Trim()))
            {
                result.Message = "Error: Name field cannot be empty"; 
                return result;
            }
            if (limite <= sizeImg)
            {
                result.Message = "Error: Image cannot be larger than 2Mb";
                return result;
            }
            if ( !(allowerMimes.Contains(type.ToLower())))
            {
                result.Message = "Error: Type Invalid";
                return result;
            }

            var picture = new PictureEntity()
            {
                Name = put.Key,
                Size = sizeImg,
            };


            try
            {
               put.Key = $"{Crypto.ConvertToCrypto(DateTime.Now.ToString())}-{put.Key}";

                var res = await s3.PutObjectAsync(put);


                picture.Url = $"https://ltjuploadimage.s3.amazonaws.com/{put.Key}";
                picture.Key = put.Key;

                await InsertAsync(picture);

                result.Status = true;
                result.Value = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public Task<ValidResult<bool>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PictureEntity> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ValidResult<List<PictureEntity>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ValidResult<bool>> InsertAsync(PictureEntity obj)
        {
            var result = new ValidResult<bool>();
            try
            {
                await _picture.InsertAsync(obj);
                result.Status = true;
                result.Value = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public Task<ValidResult<bool>> UpdateAsync(PictureEntity obj)
        {
            throw new NotImplementedException();
        }



    }
}
