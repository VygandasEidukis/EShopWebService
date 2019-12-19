using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models.Tests
{
    [TestClass()]
    public class EuklideanModelTests
    {
        public EuklideanModel euklidean { get; set; }
        public List<ProductModel> products { get; set; }

        [TestInitialize()]
        public void init()
        {
            euklidean = new EuklideanModel() { Price = 10, ProductType = new ProductType() { Id = 1, TypeName = "testType" } };
            products = new List<ProductModel>() { new ProductModel() { Price = 10 }, new ProductModel() { Price = 5 }, new ProductModel() { Price = 15 }, new ProductModel() { Price = 20 } };
        }

        [TestMethod()]
        public void CalculateClassificationValueTest()
        {
            var expected = new ProductModel() { ClassificationValue = 5 }.ClassificationValue;
            euklidean.CalculateClassificationValue(products);
            var actual = products[1].ClassificationValue;
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod()]
        public void RetrieveValidProductsTest_ProductsWithinRange_Success()
        {
            var expected = 4;
            euklidean.CalculateClassificationValue(products);
            var actual = euklidean.RetrieveValidProducts(4, products).Count;
            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}