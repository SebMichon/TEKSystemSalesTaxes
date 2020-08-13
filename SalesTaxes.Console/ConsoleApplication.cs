using SalesTaxes.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.AppConsole
{
    public class ConsoleApplication
    {

        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public ConsoleApplication(ILogger logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public void Run()
        {
           
            // Input 1            
            var cart1 = (ICart)_serviceProvider.GetService(typeof(ICart));
            cart1.CartNo = 1;
            cart1.AddCartItem(1, "book", 12.49m);
            cart1.AddCartItem(1, "music CD", 14.99m);
            cart1.AddCartItem(1, "chocolate bar", 0.85m);
            cart1.LogReceipt();

            // Input 2
            var cart2 = (ICart)_serviceProvider.GetService(typeof(ICart));
            cart2.CartNo = 2;
            cart2.AddCartItem(1, "imported box of chocolates", 10.00m);
            cart2.AddCartItem(1, "imported bottle of perfume", 47.50m);
            cart2.LogReceipt();

            // Input 3
            var cart3 = (ICart)_serviceProvider.GetService(typeof(ICart));
            cart3.CartNo = 3;
            cart3.AddCartItem(1, "imported bottle of perfume", 27.99m);
            cart3.AddCartItem(1, "bottle of perfume", 18.99m);
            cart3.AddCartItem(1, "packet of headache pills", 9.75m);
            cart3.AddCartItem(1, "box of imported chocolates", 11.25m);
            cart3.LogReceipt();


        }


    }
}
