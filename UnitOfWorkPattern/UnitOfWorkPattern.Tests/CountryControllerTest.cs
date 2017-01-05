using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitOfWorkPattern.Controllers;
using UnitOfWorkPattern.Model;
using UnitOfWorkPattern.Service;

namespace UnitOfWorkPattern.Tests
{
    [TestClass]
    public class CountryControllerTest
    {
        private Mock<ICountryService> _countrySerivceMock;
        private CountryController objController;
        private List<Country> listCountries;

        //country controller is expect to receive ICountryService
        //so that we have to mock that
        [TestInitialize]
        public void TestInitialize()
        {
            _countrySerivceMock = new Mock<ICountryService>();
            objController = new CountryController(_countrySerivceMock.Object);
            listCountries = new List<Country>()
            {
                new Country() {Id = 1, Name = "US"},
                new Country() {Id = 2, Name = "India"},
                new Country() {Id = 3, Name = "Russia"}
            };
        }

        [TestMethod]
        public void Get_All_Country()
        {
            //Arrange
            _countrySerivceMock.Setup(x => x.GetAll()).Returns(listCountries);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<Country>;

            //Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);
        }

        [TestMethod]
        public void Valid_Country_Create()
        {
            //Arrange
            Country country = new Country() { Name = "test1" };

            //Act
            var result = (RedirectToRouteResult)objController.Create(country);

            //Assert
            _countrySerivceMock.Verify(m => m.Create(country), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Invalid_Country_Create()
        {
            //Arrange
            Country country = new Country() { Name = "" };
            objController.ModelState.AddModelError("Error", "Something went wrong");
            //Act
            var result = (ViewResult)objController.Create(country);

            //Assert
            _countrySerivceMock.Verify(m => m.Create(country), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }
    }
}