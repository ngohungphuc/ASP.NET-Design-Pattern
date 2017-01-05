using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitOfWorkPattern.Model;
using UnitOfWorkPattern.Repository;
using UnitOfWorkPattern.Service;

namespace UnitOfWorkPattern.Tests
{
    [TestClass]
    public class CountryServiceTest
    {
        private Mock<ICountryRepository> _mockRepository;
        private ICountryService _service;
        private Mock<IUnitOfWork> _mockUnitOFWork;
        private List<Country> listCountries;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<ICountryRepository>();
            _mockUnitOFWork = new Mock<IUnitOfWork>();
            _service = new CountryService(_mockUnitOFWork.Object, _mockRepository.Object);
            listCountries = new List<Country>() {
               new Country() { Id = 1, Name = "US" },
               new Country() { Id = 2, Name = "India" },
               new Country() { Id = 3, Name = "Russia" }
            };
        }

        [TestMethod]
        public void Country_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(listCountries);

            //Act
            List<Country> results = _service.GetAll() as List<Country>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void Can_Add_Country()
        {
            //Arrange
            int id = 1;
            Country country = new Country() { Name = "UK" };
            _mockRepository.Setup(m => m.Add(country)).Returns((Country coun) =>
            {
                coun.Id = id;
                return coun;
            });

            //Act
            _service.Create(country);

            //Assert
            Assert.AreEqual(id, country.Id);
            _mockUnitOFWork.Verify(m => m.Commit(), Times.Once);
        }
    }
}