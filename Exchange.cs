﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventHandler_Stocks_.Utility;

namespace EventHandler_Stocks_
{
    internal class Exchange
    {
        private string name = "Event Demo Stock Exchange";
        List<Stock> Stocks = new List<Stock>()
        {
            new Stock("PROG"),
            new Stock("C0D3"),
            new Stock("BYTE"),
            new Stock("JPDR"),
            new Stock("CBRP"),
            new Stock("RELR")
        };
        public void Open()
        {
            SetStockPrices();

            Run();
        }
        private void Menu()
        {
            Print("Press x to exit, any other key to check for price changes again.");
            string input = Console.ReadLine();
            if (input.ToLower() != "x")
            {
                Run();
            }

        }
        private void Run()
        {
            ClearScreen();
            Print(name);
            Print("--------------------------");
            PrintAllStockPrices();
            Print("--------------------------");

            Print("\n~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Print("Stock prices are updating!");
            Print("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            //call setstockprices on all stocks in the list
            foreach (Stock s in Stocks)
            {
                s.PriceFluctuation();
            }

            Print(name);
            Print("--------------------------");
            PrintAllStockPrices();
            Print("--------------------------");
            Menu();

        }
        private void SetStockPrices()
        {
            foreach (Stock s in Stocks)
            {
                // Register with the PriceChanged event
                s.PriceChanged += s.stock_PriceChanged;
                s.Price = Utility.RandomNumber.Next(20, 30);
            }
        }

        private void PrintAllStockPrices()
        {
            foreach (Stock s in Stocks)
            {
                Print($"The price of {s.Symbol} is {s.Price}");
            }
        }
    }
}
