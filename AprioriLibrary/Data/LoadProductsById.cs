using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprioriLibrary.Interfaces;
using AprioriLibrary.Model;

namespace AprioriLibrary.Data
{
    class LoadProductsById : ILoadProducts
    {
        public List<Product> LoadProducts(List<List<int>> allProducts)
        {
            List<Product> products = new List<Product>();
            foreach (int id in RetrieveUniqueIds(allProducts))
            {
                var product = new Product(id.ToString());
                product = ExtractRepetition(allProducts, product);
                products.Add(product);
            }

            return products;
        }

        private List<int> RetrieveUniqueIds(List<List<int>> allProducts)
        {
            List<int> unique = new List<int>();
            foreach (var transaction in allProducts)
            {
                foreach (var product in transaction)
                {
                    if (!unique.Contains(product))
                        unique.Add(product);
                }
            }

            return unique;
        }

        private Product ExtractRepetition(List<List<int>> allProducts, Product uniqueProduct)
        {
            foreach (var transaction in allProducts)
            {
                foreach (var product in transaction)
                {
                    if (uniqueProduct.itemset[0] == product.ToString())
                        uniqueProduct.count++;
                }
            }

            return uniqueProduct;
        }
    }
}
