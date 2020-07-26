using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;

namespace SalesTaxes.BusinessLayer.Helper
{
    public static class MathHelper
    {

        /// <summary>
        /// Rounded up to the nearest 0.05
        /// </summary>
        /// <param name="amount">Amount to round up</param>
        /// <returns>Rounded up amount (to the nearest 0.05)</returns>
        public static decimal RoundUpNearest5Cents(decimal amount)
        {
            return Math.Ceiling(amount * 20) / 20;            
            
        }

        /// <summary>
        /// Format an amount (as a string) with 2 digits for the cents (ex: 12.85)
        /// </summary>
        /// <param name="amount">Amount to be formatted</param>
        /// <returns>Formatted amount as a string</returns>
        public static string FormatAmount(decimal amount) => amount.ToString("F", CultureInfo.InvariantCulture);

    }
}
