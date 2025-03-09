/*
 * Stock Prices (Event Handlers)
 * Roberto A. Ramirez
 * 3/9/2025
 * Modified and extended from example code at http://www.albahari.com/nutshell/E9-CH04.aspx
 */

using System;

namespace EventHandler_Stocks_
{
    internal class Program
    {
        static void Main()
        {
            
                Console.Title = "Programming II Stock Prices (Event Handlers) by Roberto A. Ramirez";
                Exchange exchange = new Exchange();
                exchange.Open();
            
        }
    }
}
