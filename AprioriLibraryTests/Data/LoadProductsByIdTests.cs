using Microsoft.VisualStudio.TestTools.UnitTesting;
using AprioriLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprioriLibrary.Model;

namespace AprioriLibrary.Data.Tests
{
    [TestClass()]
    public class LoadProductsByIdTests
    {
        public List<List<int>> InitialStaticList;
        public LoadProductsById loadProductsById;

        [TestInitialize()]
        public void init()
        {
            InitialStaticList = new List<List<int>>() { new List<int>() { 1, 2 }, new List<int>() { 1, 3 }, new List<int>() { 2, 3 }, new List<int>() { 1, 2, 3, 4 } };
            loadProductsById = new LoadProductsById();
        }

        [TestMethod()]
        public void LoadProductsTest_CountOfProductsInInitialStaticList_Equals_Success()
        {
            var expected = 4;
            var actual = loadProductsById.LoadProducts(InitialStaticList).Count;
            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}