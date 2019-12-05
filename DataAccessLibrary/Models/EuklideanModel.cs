using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Logic;

namespace DataAccessLibrary.Models
{
    public class EuklideanModel
    {
        public double Price { get; set; }
        public ProductType ProductType { get; set; }

        public List<ProductModel> SearchProductsList()
        {
            if (Price == 0 || ProductType == null)
                return null;
            List<ProductModel> productsFromType = ProductProcessor.GetProductsByType(ProductType.Id);
            CalculateClassificationValue(productsFromType);
            return RetrieveValidProducts(3, productsFromType);
        }

        public void CalculateClassificationValue(List<ProductModel> products)
        {
            List<double> productsPrice = new List<double>();
            foreach (var product in products)
            {
                product.ClassificationValue = Math.Sqrt( Math.Pow(product.Price - Price, 2));
            }
        }

        public List<ProductModel> RetrieveValidProducts(int count, List<ProductModel> products)
        {
            products = products.OrderBy(p => p.ClassificationValue).ToList();
            
            var validProducts = new List<ProductModel>();
            for (int i = 0; i < count; i++)
            {
                validProducts.Add(products[i]);
            }
            return validProducts;
        }
    }
}
