using Xunit;
using SalesTaxes.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.BusinessLayer.Tests
{
    public class ProductTests
    {

        [Theory]
        [InlineData("imported box of chocolates", true)]
        [InlineData("packet of headache pills", true)]
        [InlineData("book", true)]
        [InlineData("imported bottle of perfume", false)]
        [InlineData("music CD", false)]
        public void IsTaxExempt_ShouldDetermneIfProductCategoryIsTaxExempt(string productName, bool expectedResult)
        {
            // Arrange
            var product = new Product() { ProductName = productName };

            // Act
            bool actualResult = product.IsTaxExempt();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("imported box of chocolates", 0)]
        [InlineData("packet of headache pills", 0)]
        [InlineData("book", 0)]
        [InlineData("imported bottle of perfume", 0.10)]
        [InlineData("music CD", 0.10)]
        public void SalesTaxRateTest(string productName, decimal expectedResult)
        {
            // Arrange
            var product = new Product() { ProductName = productName };

            // Act
            decimal actualResult = product.SalesTaxRate();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("imported box of chocolates", 0.05)]
        [InlineData("packet of headache pills", 0)]
        [InlineData("book", 0)]
        [InlineData("imported bottle of perfume", 0.05)]
        [InlineData("music CD", 0)]
        public void ImportTaxRateTest(string productName, decimal expectedResult)
        {
            // Arrange
            var product = new Product() { ProductName = productName };

            // Act
            decimal actualResult = product.ImportTaxRate();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}