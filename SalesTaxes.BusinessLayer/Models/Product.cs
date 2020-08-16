using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxes.BusinessLayer
{
    public class Product : IProduct
    {
           private string _productName = "";

        public string ProductName
        {
            get { return _productName; }
            set 
            {
                // we dont allow for Null for Product name
                if (value == null) value = "";
                _productName = value; 
            }
        }


        public bool IsImported => ProductName.Contains("imported");

        /// <summary>
        /// Basic sales tax is applicable at a rate of 10% on all goods, except books, food, and medical products that are exempt. 
        /// </summary>
        /// <param name="productName"></param>
        /// <returns>Sales tax rate</returns>
        public decimal SalesTaxRate()
        {
           decimal salesTaxRate = IsTaxExempt() ? 0 : 0.10m;

            return salesTaxRate;
        }

        /// <summary>
        /// Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions.  
        /// </summary>
        /// <returns>Import tax rate</returns>
        public decimal ImportTaxRate()
        {
            decimal importTaxRate = IsImported ? 0.05m : 0;

            return importTaxRate;
        }

        /// <summary>
        /// Indicates if the product is Sales Taxes exempt
        /// Basic sales tax is applicable at a rate of 10% on all goods, except books, food, and medical products that are exempt. 
        /// </summary>
        /// <returns></returns>
        public bool IsTaxExempt()
        {
            var TaxExemptProduct = new[] { "chocolate", "book", "headache pills" };
            bool isTaxExempt = TaxExemptProduct.Any(c => ProductName.Contains(c));
                        
            return isTaxExempt;
        }
    }
}
