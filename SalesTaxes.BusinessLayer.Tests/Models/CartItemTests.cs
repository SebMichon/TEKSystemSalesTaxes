using Xunit;
using SalesTaxes.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace SalesTaxes.BusinessLayer.Tests
{
    public class CartItemTests
    {
        [Theory]
        [InlineData(1,  12.49, 12.49)]
        [InlineData(2, 15, 30)]


        public void TotalBeforeTaxes_ShouldCalculateTotal(int quantity,  decimal shelfPrice, decimal expectedTotal)
        {
            // Arrange
            var mockProduct = new Mock<IProduct>();
            var cartItem = new CartItem(mockProduct.Object) { Quantity = quantity, ShelfPrice = shelfPrice };

            // Act
            var actualTotal = cartItem.TotalBeforeTaxes;

            // Assert
            Assert.Equal(expectedTotal, actualTotal);
        }


        [Theory]
        [InlineData(1, 12.49, 0, 0)]
        [InlineData(1, 10, 0.10, 1)]
        [InlineData(2, 10, 0.10, 2)]


        public void SalesTaxes_ShouldCalculateSalesTaxes(int quantity, decimal shelfPrice, decimal salesTaxRate, decimal expectedSalesTaxes)
        {
            // Arrange
            var mockProduct = new Mock<IProduct>();
            var cartItem = new CartItem(mockProduct.Object) { Quantity = quantity, ShelfPrice = shelfPrice };

            mockProduct.Setup(p => p.SalesTaxRate()).Returns(salesTaxRate);

            // Act
            var actualSalesTaxes = cartItem.SalesTaxes;

            // Assert
            Assert.Equal(expectedSalesTaxes, actualSalesTaxes);
        }



        [Theory]
        [InlineData(1, 100, 0, 0)]
        [InlineData(1, 100, 0.05, 5)]
        [InlineData(2, 100, 0.05, 10)]


        public void SalesTaxes_ShouldCalculateImportTaxes(int quantity, decimal shelfPrice, decimal importTaxRate, decimal expectedSalesTaxes)
        {
            // Arrange
            var mockProduct = new Mock<IProduct>();
            var cartItem = new CartItem(mockProduct.Object) { Quantity = quantity, ShelfPrice = shelfPrice };

            mockProduct.Setup(p => p.ImportTaxRate()).Returns(importTaxRate);

            // Act
            var actualSalesTaxes = cartItem.ImportTaxes;

            // Assert
            Assert.Equal(expectedSalesTaxes, actualSalesTaxes);
        }

        [Theory]
        [InlineData(1, "book", 12.49, "1 book: 12.49")]
        [InlineData(1, "music CD", 14.99, "1 music CD: 16.49")]
        [InlineData(1, "chocolate bar", 0.85, "1 chocolate bar: 0.85")]

        [InlineData(1, "imported box of chocolates", 10.00, "1 imported box of chocolates: 10.50")]
        [InlineData(1, "imported bottle of perfume", 47.50, "1 imported bottle of perfume: 54.65")]


        [InlineData(1, "imported bottle of perfume", 27.99, "1 imported bottle of perfume: 32.19")]
        [InlineData(1, "bottle of perfume", 18.99, "1 bottle of perfume: 20.89")]
        [InlineData(1, "packet of headache pills", 9.75, "1 packet of headache pills: 9.75")]
        [InlineData(1, "imported box of chocolates", 11.25, "1 imported box of chocolates: 11.85")]


        public void GenerateReceiptLine_ShouldFormatReceiptLineCorrectly(int quantity, string productName, decimal shelfPrice, string expectedResult)
        {
            // Arrange
            var product = new Product();
            var cartItem = new CartItem(product) { Quantity = quantity, ShelfPrice = shelfPrice };
            cartItem.Product.ProductName = productName;

            // Act
            string actualResult = cartItem.GenerateReceiptLine();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

    }
}