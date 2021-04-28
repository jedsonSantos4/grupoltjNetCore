using Amazon.S3;
using Amazon.S3.Model;
using AppCore.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IAmazonS3 amazonS3;
        private readonly IPictureService picture;

        private string bucketName { get; set; }


        public ImageController(IAmazonS3 amazonS3,IPictureService _picture)
        {
            this.amazonS3 = amazonS3;
            picture = _picture;
            bucketName = "ltjuploadimage";

        }

       

        [HttpPost]
        public async Task<IActionResult> PostImage([FromForm] IFormFile file)
        {
           
                var putres = new PutObjectRequest()
                {
                    BucketName = "ltjuploadimage",
                    Key = file.FileName,
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType,
                    CannedACL = S3CannedACL.PublicRead,
                    

                };

              var res =  await picture.AWSInsertAsync(putres, amazonS3, file.Length,file.ContentType);

                if (!res.Status && res.Message.Contains("Err"))
                    return NotFound(res.Message);
                else if(!res.Status)
                    return NotFound(new { message = "Usuários não localizados" });
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string imgName)
        {
            var resqt = new GetObjectRequest()
            {
                BucketName = "ltjuploadimage",
                Key = imgName
            };

            using GetObjectResponse respo = await this.amazonS3.GetObjectAsync(resqt);
            using Stream respStream = respo.ResponseStream;
            var stream = new MemoryStream();
            await respStream.CopyToAsync(stream);
            stream.Position = 0;

            var tese = new Microsoft.AspNetCore.Mvc.FileStreamResult(stream, respo.Headers["Content-Type"])
            {
                FileStream = stream
            };


            return new Microsoft.AspNetCore.Mvc.FileStreamResult(stream, respo.Headers["Content-Type"])
            {
                FileStream = stream
            };

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string imgName)
        {
            var resqt = new DeleteObjectRequest ()
            {
                BucketName = "ltjuploadimage",
                Key = imgName
            };

            var resp = await this.amazonS3.DeleteObjectAsync(resqt);

            return Ok(resp);
           

        }
    }
}
