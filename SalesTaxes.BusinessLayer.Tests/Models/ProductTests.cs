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
        [InlineData(null, false)]
        [InlineData("", false)]
        public void IsTaxExempt_ShouldDetermneIfProductCategoryIsTaxExempt(string productName, bool expectedIsTaxExempt)
        {
            // Arrange
            var product = new Product() { ProductName = productName };

            // Act
            bool actualIsTaxExempt = product.IsTaxExempt();

            // Assert
            Assert.Equal(expectedIsTaxExempt, actualIsTaxExempt);
        }

        [Theory]
        [InlineData("imported box of chocolates", 0)]
        [InlineData("packet of headache pills", 0)]
        [InlineData("book", 0)]
        [InlineData("imported bottle of perfume", 0.10)]
        [InlineData("music CD", 0.10)]
        [InlineData(null, 0.10)]
        public void SalesTaxRateTest(string productName, decimal expectedSalesTaxRate)
        {
            // Arrange
            var product = new Product() { ProductName = productName };

            // Act
            decimal actualSalesTaxRate = product.SalesTaxRate();

            // Assert
            Assert.Equal(expectedSalesTaxRate, actualSalesTaxRate);
        }

        [Theory]
        [InlineData("imported box of chocolates", 0.05)]
        [InlineData("packet of headache pills", 0)]
        [InlineData("book", 0)]
        [InlineData("imported bottle of perfume", 0.05)]
        [InlineData("music CD", 0)]
        [InlineData(null, 0)]
        public void ImportTaxRateTest(string productName, decimal expectedImportTaxRate)
        {
            // Arrange
            var product = new Product() { ProductName = productName };

            // Act
            decimal actualImportTaxRate = product.ImportTaxRate();

            // Assert
            Assert.Equal(expectedImportTaxRate, actualImportTaxRate);
        }
    }
}