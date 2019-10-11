﻿using DataAccessLibrary.Logic;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EShopWebUI.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        public List<ProductModel> Get()
        {
            return ProductProcessor.GetProducts();
        }

        // GET: api/Product/5
        public ProductModel Get(int id)
        {
            return ProductProcessor.GetProduct(id);
        }

        // POST: api/Product
        public void Post([FromBody]ProductModel value)
        {
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