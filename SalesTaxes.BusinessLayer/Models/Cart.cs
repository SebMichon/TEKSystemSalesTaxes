using SalesTaxes.BusinessLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxes.BusinessLayer
{
    public class Cart : ICart
    {
        public int CartNo { get; set; }

        public List<ICartItem> ListCartItem = new List<ICartItem>();

        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public Cart(ILogger logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public ICartItem AddCartItem(int quantity, string productName, decimal shelfPrice)
        {
            var cartItem = (ICartItem)_serviceProvider.GetService(typeof(ICartItem));
            cartItem.Quantity = quantity;
            cartItem.ShelfPrice = shelfPrice;
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
