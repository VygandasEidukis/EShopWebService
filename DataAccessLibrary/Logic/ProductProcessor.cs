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
            var sql = $"select * from dbo.Product;";
            var products = DataAccess.DataAccess.LoadData<ProductModel>(sql);

            //get product images
            foreach(ProductModel product in products)
            {
                GetProductImages(product);
            }

            return products;
        }

        public static ProductModel GetProduct(int id)
        {
            var sql = $"select * from dbo.Product WHERE Id = {id};";

            var product = DataAccess.DataAccess.GetSingleData<ProductModel>(sql);

            //get product images
            GetProductImages(product);

            return product;
        }

        public static ProductModel GetProductImages(ProductModel product)
        {
            product.ProductImages = ImageProcessor.GetProductImages(product.Id);
            return product;
        }


    }
}
