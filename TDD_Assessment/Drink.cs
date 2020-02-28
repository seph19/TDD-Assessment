using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_Assessment
{
    public class Drink : VendingItem
    {
        public const string Message = "Thanks for buying!";

        public Drink(
            string productName,
            decimal price,
            int itemsRemaining)
                : base(
                productName,
                price,
                itemsRemaining,
                Message)
        {
        }
    }
}
