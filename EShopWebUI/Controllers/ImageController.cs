using DataAccessLibrary.DataAccess;
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
        public void PostProductImage([FromBody]SingleImageModel image, int ProductID)
        {
            var saveImage = new ImageModel();
            var imagePath = HostingEnvironment.MapPath("~/Resources/Images/") + $"{ImageHelper.GenerateRandomName()}{image.FileExtension}";
            saveImage.SaveBytesToImage(image.Image, imagePath);
            ImageProcessor.AddProductImage(new ImageModel() { ImagePath = Path.GetFileName(imagePath), ProductID = ProductID });
        }

        [HttpGet]
        [Route("api/Image/{ProductID:int}")]
        public List<ImageModel> GetProductImages(int productId)
        {
            return ImageProcessor.GetProductImages(productId);
        }

    }
}
