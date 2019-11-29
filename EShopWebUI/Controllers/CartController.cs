using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLibrary.Logic;
using DataAccessLibrary.Models;

namespace EShopWebUI.Controllers
{
    public class CartController : ApiController
    {
        //create cart for user (if doesn't have one available)
        [HttpGet]
        [Route("api/Cart/Create/{UserID:int}")]
        public string CreateCart(int userId)
        {
            CartProcessor.CreateCart(UserProcessor.GetUser(userId));
            return "Cart created";
        }

        //Add product
        [HttpPost]
        [Route("api/Cart/Add/{UserID:int}")]
        public string AddProduct([FromBody] ProductModel product, int userId)
        {
            if (product == null) return "Failed to add product, no product received";
            CartProcessor.AddProductToCart(product, UserProcessor.GetUser(userId));
            return "Product has been added";
        }

        //Add product
        [HttpPost]
        [Route("api/Cart/Remove/{UserID:int}")]
        public string RemoveProduct([FromBody] ProductModel product, int userId)
        {
            if (product == null) return "Failed to remove product, no product received";
            CartProcessor.RemoveProductFromCart(product, UserProcessor.GetUser(userId));
            return "Product has been removed";
        }
    }
}
