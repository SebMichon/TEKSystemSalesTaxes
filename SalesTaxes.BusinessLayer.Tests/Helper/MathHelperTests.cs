using SalesTaxes.BusinessLayer.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SalesTaxes.BusinessLayer.Helper.Tests
{
   
    public class MathHelperTests
    {
        [Theory]
        [InlineData(1.231, 1.25)]
        [InlineData(1.27, 1.30)]

        public void RoundUpNearest5Cents_ShouldRoundUpToNearest5Cents(decimal amount, decimal expectedResult)
        {
            // Arrange

            // Act
            var actualResult = MathHelper.RoundUpNearest5Cents(amount);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }

        [Theory]
        [InlineData(0.8500, "0.85")]
        [InlineData(0003, "3.00")]
        [InlineData(2.1, "2.10")]

        public void FormatAmount_ShouldFormatwith2DigitsForCents(decimal amount, string expectedResult)
        {
            // Arrange

            // Act
            var actualResult = MathHelper.FormatAmount(amount);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }


    }
}