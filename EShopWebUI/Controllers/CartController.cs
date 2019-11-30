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
        [Route("api/Cart/Create/{userId:int}")]
        public string CreateCart(int userId)
        {
            try
            {
                CartProcessor.CreateCart(UserProcessor.GetUser(userId));
                return "Cart created";
            }
            catch (Exception e)
            {
                return $"Cart creation failed: {e.Message}";
            }
        }

        //Add product
        [HttpGet]
        [Route("api/Cart/Add/{userId:int}/{productId:int}")]
        public string AddProduct(int productId, int userId)
        {
            CartProcessor.AddProductToCart(productId, UserProcessor.GetUser(userId));
            return "Product has been added";
        }

        //Remove product
        [HttpGet]
        [Route("api/Cart/Remove/{userId:int}/{productId:int}")]
        public string RemoveProduct(int productId, int userId)
        {
            CartProcessor.RemoveProductFromCart(productId, userId);
            return "Product has been removed";
        }
        
        //return cart products
        [HttpGet]
        [Route("api/Cart/{userId:int}")]
        public List<ProductModel> GetProducts(int userId)
        {
            return CartProcessor.GetCartProducts(userId);
        }
    }
}
