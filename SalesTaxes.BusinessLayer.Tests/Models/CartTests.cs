using Xunit;
using SalesTaxes.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Microsoft.Extensions.DependencyInjection;

namespace SalesTaxes.BusinessLayer.Tests
{
    public class CartTests
    {
        
        [Theory]
        [InlineData(1, "book", 12.49)]
        public void AddCartItem_ShouldSetPropertiesCorrectly(int quantity, string productName, decimal shelfPrice)
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();

            var serviceProvider=RegisterServices();

            var cart = new Cart(mockLogger.Object, serviceProvider);

            // Act
            var cartItem = cart.AddCartItem(quantity, productName, shelfPrice);

            // Assert
            Assert.Equal(quantity, cartItem.Quantity);
            Assert.Equal(productName, cartItem.Product.ProductName);
            Assert.Equal(shelfPrice, cartItem.ShelfPrice);

            DisposeServices(serviceProvider);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void AddCartItem_ShouldAllowToAddManyCartItems(int nbCartItemToAdd)
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            var serviceProvider = RegisterServices();
            var cart = new Cart(mockLogger.Object, serviceProvider);

            // Act
            for (int i = 1; i <= nbCartItemToAdd; i++)
            {
                cart.AddCartItem(1, "item " + i, 10);
            }

            // Assert
            Assert.Equal(nbCartItemToAdd, cart.ListCartItem.Count);

            DisposeServices(serviceProvider);

        }

        [Theory]
        [InlineData(1, "book", 12.49,
                    1, "music CD", 14.99,
                    "Output 1:\t1 book: 12.49\t1 music CD: 16.49\tSales Taxes: 1.50 Total: 28.98")]
        public void GenerateReceipt_ShouldProduceExpectedReceiptFormat(int item1Quantity, string item1ProductName, decimal item1ShelfPrice,
                                        int item2Quantity, string item2ProductName, decimal item2ShelfPrice,
                                        string expectedResult)
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();

            var serviceProvider = RegisterServices();

            var cart = new Cart(mockLogger.Object, serviceProvider) { CartNo = 1 };
            cart.AddCartItem(item1Quantity, item1ProductName, item1ShelfPrice);
            cart.AddCartItem(item2Quantity, item2ProductName, item2ShelfPrice);

            // Act
            string acualResult = cart.GenerateReceipt();

            // Assert
            acualResult = acualResult.Replace(Environment.NewLine, "");
            Assert.Equal(expectedResult, acualResult);
        }

        [Fact()]
        public void LogReceipt_ShouldCallLoggerWithProductInfo()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            mockLogger.Setup(mock => mock.Log(It.IsAny<String>()));

            var serviceProvider = RegisterServices();

            var cart = new Cart(mockLogger.Object, serviceProvider) ;
            var productName = "book";
            cart.AddCartItem(1, productName, 20);
            

            // Act
            cart.LogReceipt();

            // Assert
            mockLogger.Verify(mock => mock.Log(It.Is<string>(s => s.Contains(productName))), Times.Once);
        }


        private static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IProduct, Product>();
            services.AddTransient<ICartItem, CartItem>();

            return services.BuildServiceProvider(true);
        }




        private static void DisposeServices(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}