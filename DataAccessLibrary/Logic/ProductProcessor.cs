using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Logic
{
    public static class ProductProcessor
    {
        public static List<ProductModel> GetProducts()
        {
            return new List<ProductModel>();
        }

        public static ProductModel GetProduct(int id)
        {
            return new ProductModel() { Description = "test", Name = "test", Id = 1, UserID = 1, Price = 1.5f };
        }
    }
}
