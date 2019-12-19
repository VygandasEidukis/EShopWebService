using DataAccessLibrary.Logic;
using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace EShopWebUI.Controllers
{
    public class ProductController : ApiController
    {
        [HttpPost]
        [Route("api/Product/Update/{ProductID:int}")]
        public void UpdateProduct([FromBody] ProductModel product)
        {
            ProductProcessor.UpdateProduct(product);
        }

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

        // GET: api/Product/Type/
        [HttpGet]
        [Route("api/Product/Type/")]
        public List<ProductType> GetProductTypes()
        {
            return ProductTypeProcessor.GetAllTypes();
        }

        // POST: api/Product
        public async Task<int> Post([FromBody] ProductModel product)
        {
            int id = await ProductProcessor.CreateProduct(product);
            return id;
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
