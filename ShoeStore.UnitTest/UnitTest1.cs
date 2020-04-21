using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeStore.Domain.Abstract;
using Moq;
using ShoeStore.WebUI.Controllers;
using ShoeStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShoeStore.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Receive_Categories()
        {
            //Arrange
            Mock<IProductRepos> mock = new Mock<IProductRepos>();
            mock.Setup(x => x.Categories).Returns(new Category[]
            {
                new Category{CategoryId=1, CategoryName="C1"},
                new Category{CategoryId=2, CategoryName="C2"}
            });

            NavController controller = new NavController(mock.Object);

            //Act
            var result = ((IEnumerable<Category>)controller.CategoryMenu().Model).ToArray();

            //Assert
            Assert.AreEqual("C1", result[0].CategoryName);
            Assert.AreEqual(2, result.Length);
        }
        
    }
}
