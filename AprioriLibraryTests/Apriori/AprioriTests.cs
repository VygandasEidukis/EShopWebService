﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AprioriLibrary.Model;
using System;

namespace AprioriLibrary.Apriori.Tests
{
    [TestClass()]
    public class AprioriTests
    {
        public float MinSupport { get; set; }
        public float MinConfidence { get; set; }
        public int TransactionAmount { get; set; }
        public List<Product> InitialProducts { get; set; }
        public List<List<int>> InitialStaticList { get; set; }
        public Apriori apriori { get; set; }

        [TestInitialize()]
        public void init()
        {
            InitialProducts = new List<Product>() { new Product("shoes"), new Product("hat"), new Product("pants"), new Product("bike"), new Product("lightbulb") };
            InitialStaticList = new List<List<int>>() { new List<int>(){ 1, 2 }, new List<int>() { 1, 3 }, new List<int>() { 2, 3 }, new List<int>() { 1, 2, 3, 4 } };
            apriori = new Apriori(InitialStaticList, 1, 1);
        }

        [TestMethod()]
        public void getItemCountTest_GetsItemCount_WithCorrectData_Pass()
        {
            var actual = apriori.getItemCount(InitialProducts, new Product("shoes"));
            var expected = 0;
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod()]
        public void getItemCountTest_GetsItemCount_WithFalseData_Fail()
        {
            Assert.ThrowsException<Exception>(()=> apriori.getItemCount(InitialProducts, null));
        }

        [TestMethod()]
        public void is2ItemEqualsTest_FirstItemOnInitialProductList_NewProductSameName_True_Success()
        {
            Assert.IsTrue(apriori.is2ItemEquals(InitialProducts[0], new Product("shoes")));
        }

        [TestMethod()]
        public void is2ItemEqualsTest_FirstItemOnInitialProductList_NewProductDifferentName_False_Success()
        {
            Assert.IsFalse(apriori.is2ItemEquals(InitialProducts[0], new Product("bird")));
        }

        [TestMethod()]
        public void is2ItemEqualsTest_FirstItemOnInitialProductList_NoProducts_Flse_Fail()
        {
            Assert.ThrowsException<Exception>(()=> apriori.is2ItemEquals(null, null));
        }
    }
}