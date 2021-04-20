using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IAmazonS3 amazonS3;

        public ImageController(IAmazonS3 amazonS3)
        {
            this.amazonS3 = amazonS3;
        }

        [HttpGet]
        public IActionResult GetImage() {

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostImage([FromForm] IFormFile file)
        {
            try
            {
                var putres = new PutObjectRequest()
                {
                    BucketName = "ltjuploadimage",
                    Key = file.FileName,
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType,

                };

                var res = await this.amazonS3.PutObjectAsync(putres);
            }
            catch (Exception es)
            {

                throw;
            }

         

            return Ok();
        }
    }
}
