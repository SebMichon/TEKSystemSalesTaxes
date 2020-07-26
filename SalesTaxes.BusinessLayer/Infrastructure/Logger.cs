using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.BusinessLayer
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
