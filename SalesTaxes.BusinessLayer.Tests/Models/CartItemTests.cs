using Xunit;
using SalesTaxes.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.BusinessLayer.Tests
{
    public class CartItemTests
    {
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
            var cartItem = new CartItem() { Quantity = quantity, ShelfPrice = shelfPrice };
            cartItem.Product.ProductName = productName;

            // Act
            string actualResult = cartItem.GenerateReceiptLine();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}