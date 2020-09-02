using Microsoft.Extensions.DependencyInjection;
using SalesTaxes.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.AppConsole
{
    /// <summary>
    /// This class will add DI container for a Console App
    /// </summary>
    public class DIContainer
    {

        public static IServiceProvider? ServiceProvider;

        public static void RunConsoleApplication()
        {
            RegisterServices();
            IServiceScope scope = ServiceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILogger , Logger>();
            services.AddTransient<IProduct, Product>();
            services.AddTransient<ICartItem, CartItem>();
            services.AddTransient<ICart, Cart>();
            services.AddSingleton<ConsoleApplication>();
            ServiceProvider = services.BuildServiceProvider(true);
        }


        private static void DisposeServices()
        {
            if (ServiceProvider == null)
            {
                return;
            }
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }


    }
}
