using SalesTaxes.BusinessLayer.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.BusinessLayer
{
    public class CartItem : ICartItem
    {

        public CartItem(IProduct product)
        {
            Product = product;
        }

        public IProduct Product { get; }

        public int Quantity { get; set; }

        public decimal ShelfPrice { get; set; }

        public decimal TotalBeforeTaxes => Quantity * ShelfPrice;

        public decimal SalesTaxes => Product.SalesTaxRate() * TotalBeforeTaxes;

        public decimal ImportTaxes => Product.ImportTaxRate() * TotalBeforeTaxes;

        public decimal TotalOfTaxes => MathHelper.RoundUpNearest5Cents(SalesTaxes + ImportTaxes);

        public decimal TotalWithTaxes => TotalBeforeTaxes + TotalOfTaxes;

        public string GenerateReceiptLine()
        {
            return $"{Quantity} {Product.ProductName}: {MathHelper.FormatAmount(TotalWithTaxes)}";
        }
    }
}
