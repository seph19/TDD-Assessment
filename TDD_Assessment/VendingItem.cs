using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_Assessment
{
    public class VendingItem
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int ItemsRemaining { get; set; }
        public string MessageWhenVended { get; set; }
        public string MessageWhenSoldOut { get; set; }

        public VendingItem()
        {

        }

        public VendingItem(string productName, decimal price, int itemsRemaining, string messageWhenVended)
        {
            this.ProductName = productName;
            this.Price = price;
            this.ItemsRemaining = itemsRemaining;
            this.MessageWhenVended = messageWhenVended;
            this.MessageWhenSoldOut = $"Sold out of {this.ProductName}!\nBuy something else!";
        }

        public bool RemoveItem()
        {
            if (this.ItemsRemaining > 0)
            {
                this.ItemsRemaining--;
                return true;
            }
            return false;
        }
        public bool AddItem()
        {

            this.ItemsRemaining++;
            return true;

        }
    }
}
