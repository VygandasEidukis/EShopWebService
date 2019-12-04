using DataAccessLibrary.Logic;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DataAccessLibrary.Models;
using System.Web.Http;

namespace EShopWebUI.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet]
        [Route("api/Search/username/{username}")]
        public List<UserModel> SearchUserByUsername(string username)
        {
            return SearchProcessor.SearchByUsername(username);
        }

        [HttpPost]
        [Route("api/Product/Search/Euclidean/")]
        public List<ProductModel> SearchByEuklidean([FromBody] EuklideanModel  euklidean)
        {
            return new EuklideanModel(){ Price = 450, ProductType = new ProductType(){ Id = 5, TypeName = "Zaidimai"} }.SearchProductsList();
            return euklidean.SearchProductsList();
        }
    }
}
