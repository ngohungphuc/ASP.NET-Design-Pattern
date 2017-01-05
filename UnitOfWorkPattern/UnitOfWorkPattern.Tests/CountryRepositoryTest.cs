using System;
using System.Data.Common;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitOfWorkPattern.Model;
using UnitOfWorkPattern.Repository;

namespace UnitOfWorkPattern.Tests
{
    [TestClass]
    public class CountryRepositoryTest
    {
        private DbConnection connection;
        private TestContext databaseContext;
        private CountryRepository objRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new TestContext(connection);
            objRepository = new CountryRepository(databaseContext);
        }

        [TestMethod]
        public void Country_Repository_Get_ALL()
        {
            //Act
            var result = objRepository.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);
        }

        [TestMethod]
        public void Country_Repository_Create()
        {
            //Arrange
            Country c = new Country() { Name = "UK" };

            //Act
            var result = objRepository.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepository.GetAll().ToList();

            //Assert

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("UK", lst.Last().Name);
        }
    }
}