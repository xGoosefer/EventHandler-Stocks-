﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventHandler_Stocks_.Utility;

namespace EventHandler_Stocks_
{
    internal class Stock
    {
        string symbol;
        decimal price;

        public Stock(string symbol) { this.symbol = symbol; }

        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public void PriceFluctuation()
        {
            if (GetRandomInteger(4) != 1)
                Price = Price + GetRandomInteger(-15, 20);
        }


        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }

        public string Symbol { get => symbol; set => symbol = value; }

        public void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if (e.LastPrice != e.NewPrice)
                Print($"{Symbol} price has changed from {e.LastPrice} to {e.NewPrice}! The difference is {e.NewPrice - e.LastPrice}.");
        }

        public class PriceChangedEventArgs : EventArgs
        {
            public readonly decimal LastPrice;
            public readonly decimal NewPrice;

            public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
            {
                LastPrice = lastPrice; NewPrice = newPrice;
            }
        }
    }
}
