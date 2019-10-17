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
            ImageModel saveImage = new ImageModel();
            string ImagePath = HostingEnvironment.MapPath("~/Resources/Images/") + $"{ImageHelper.GenerateRandomName()}{image.FileExtension}";
            saveImage.SaveBytesToImage(image.Image, ImagePath);
            ImageProcessor.AddProductImage(new ImageModel() { ImagePath = Path.GetFileNameWithoutExtension(ImagePath), ProductID = ProductID });
        }

        [HttpGet]
        [Route("api/Image/{ProductID:int}")]
        public List<ImageModel> GetProductImages(int ProductID)
        {
            return ImageProcessor.GetProductImages(ProductID);
        }

    }
}
