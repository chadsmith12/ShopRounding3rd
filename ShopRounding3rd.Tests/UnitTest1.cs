using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopRounding3rd.Domain.Interfaces;
using ShopRounding3rd.Domain.Entities;
using ShopRounding3rd.Web.Controllers;

namespace ShopRounding3rd.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Check to see if our paginating on our products page works
        /// </summary>
        [TestMethod]
        public void Can_Paginate()
        {
            // arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(x => x.Products).Returns(new Product[]
            {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            IEnumerable<Product> result = (IEnumerable<Product>) controller.List(2).Model;

            // Assert
            Product[] products = result.ToArray();
            Assert.IsTrue(products.Length == 2 );
            Assert.AreEqual(products[0].Name, "P4");
            Assert.AreEqual(products[1].Name, "P5");
        }
        

    }
}
