using Asp.Net_Pattern.Core;
using Asp.Net_Pattern.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Asp.Net_Pattern.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private ProductRepository repo;

        [TestInitialize]
        public void TestSetup()
        {
            ProductInitalizeDB db = new ProductInitalizeDB();
            System.Data.Entity.Database.SetInitializer(db);
            repo = new ProductRepository();
        }

        [TestMethod]
        public void IsRepositoryInitWithValidNumberOfData()
        {
            var result = repo.GetProducts();
            Assert.IsNotNull(result);
            var numberOfRecord = result.Count;
            Assert.AreEqual(2, numberOfRecord);
        }

        [TestMethod]
        public void IsRepositoryAddProduct()
        {
            Product productToInsert = new Product
            {
                Id = 3,
                inStock = true,
                Name = "Salt",
                Price = 17
            };
            repo.Add(productToInsert);
            var result = repo.GetProducts();
            var numberOfRecord = result.Count;
            Assert.AreEqual(3, numberOfRecord);
        }
    }
}