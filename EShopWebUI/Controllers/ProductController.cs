using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Logic;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EShopWebUI.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        //gets all existing producsts
        public List<ProductModel> Get()
        {
                return ProductProcessor.GetProducts();

        }

        // GET: api/Product/5
        public ProductModel Get(int id)
        {
                return ProductProcessor.GetProduct(id);
        }

        // GET: api/Product/User/1
        [HttpGet]
        [Route("api/Product/User/{UserID:int}")]
        public List<ProductModel> GetUserProducts(int UserID)
        {
                return ProductProcessor.GetProductsByUser(UserID);
        }

        // POST: api/Product
        public async Task<int> Post([FromBody]ProductModel product)
        {
            int id = await ProductProcessor.CreateProduct(product);
            return id;
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]ProductModel value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
