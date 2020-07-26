using SalesTaxes.BusinessLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxes.BusinessLayer
{
    public class Cart
    {
        public int CartNo { get; set; }

        public List<CartItem> ListCartItem = new List<CartItem>();

        private readonly ILogger _logger; 

        public Cart(ILogger logger)
        {
            _logger = logger;
        }

        public CartItem AddCartItem (int quantity, string productName, decimal shelfPrice)
        {
            var cartItem = new CartItem() { Quantity = quantity, ShelfPrice = shelfPrice };
            cartItem.Product.ProductName = productName;

            ListCartItem.Add(cartItem);

            return cartItem;
        }

        public decimal TotalSalesTaxes => ListCartItem.Sum(i => i.TotalOfTaxes);

        public decimal GrandTotal => ListCartItem.Sum(i => i.TotalWithTaxes);

        public string GenerateReceipt()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Output {CartNo}:");
            
            foreach (var cartItem in ListCartItem)
            {
                sb.AppendLine("	" + cartItem.GenerateReceiptLine());
            }

            sb.AppendLine($"	Sales Taxes: {MathHelper.FormatAmount(TotalSalesTaxes)} Total: {MathHelper.FormatAmount(GrandTotal)}");

            return sb.ToString();
        }

        public void LogReceipt()
        {
            string receipt = GenerateReceipt();
            _logger.Log(receipt);
        }
    }
}
