using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AprioriLibrary.Apriori;
using DataAccessLibrary.Models;
using EShopWebUI.Controllers.Helpers;

namespace EShopWebUI.Controllers
{
    public class AprioriController : ApiController
    {
        [HttpGet]
        [Route("api/Featured")]
        public List<ProductModel> GetFeatured()
        {
            List<List<int>> test = new List<List<int>>();
            test.Add(new List<int>() { 1, 2, 3 });
            test.Add(new List<int>() { 2, 3, 4 });
            test.Add(new List<int>() { 4, 5 });
            test.Add(new List<int>() { 1, 2, 4 });
            test.Add(new List<int>() { 1, 2, 3, 5 });
            test.Add(new List<int>() { 1, 2, 3, 4, 5 }); 
            test.Add(new List<int>() { 1, 2, 3, 4, 5 });
            test.Add(new List<int>() { 1, 2, 3, 4, 5 });

            Apriori ap = new Apriori(test,(float)0.5,(float)0.3);
            List<int> featuredCollection = new List<int>();
            featuredCollection = ap.Calculate();

            return  new List<ProductModel>();
        }
    }
}
