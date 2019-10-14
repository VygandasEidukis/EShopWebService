using DataAccessLibrary.Logic;
using DataAccessLibrary.Models;
using EShopWebUI.Controllers.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace EShopWebUI.Controllers
{
    public class ImageController : ApiController
    {
        [HttpPost]
        [Route("api/Image/{ProductID:int}")]
        public async Task PostProductImage(int ProductID)
        {
            var context = HttpContext.Current;
            var root = context.Server.MapPath("~/Resources/Images");
            var provider = new MultipartFormDataStreamProvider(root);
            string name;

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                var file = provider.FileData[0];
                name = file.Headers.ContentDisposition.FileName;
                name = name.Trim('"');
                var localFileName = file.LocalFileName;
                var filePath = Path.Combine(root, name);
                File.Move(localFileName, filePath);

                string newName = ImageHelper.RenameFileToUnique(filePath);
                ImageProcessor.AddProductImage(new ImageModel() { ImagePath = newName, ProductID = ProductID });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Image/{ProductID:int}")]
        public List<ImageModel> GetProductImages(int ProductID)
        {
            return ImageProcessor.GetProductImages(ProductID);
        }

        [HttpPost]
        [Route("api/Image/Recieve")]
        public void test()
        {
        }

    }
}
