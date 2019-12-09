using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AprioriLibrary.Apriori;
using DataAccessLibrary.Logic;
using DataAccessLibrary.Models;
using EShopWebUI.Controllers.Helpers;

namespace EShopWebUI.Controllers
{
    public class AprioriController : ApiController
    {
        [HttpGet]
        [Route("api/Featured/")]
        public List<ProductModel> GetFeatured()
        {
            Apriori ap = new Apriori(OrderProcessor.GetTransactionProductIdList(),0.5f,0.3f);
            var featuredCollection = ap.Calculate();
            var products = new List<ProductModel>();
            foreach (var productId in featuredCollection)
            {
                products.Add(ProductProcessor.GetProduct(productId));
            }

            return products;
        }
    }
}
