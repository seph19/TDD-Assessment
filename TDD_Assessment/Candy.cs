using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_Assessment
{
    public class Candy : VendingItem
    {
        public const string Message = "Thanks for buying!";

        public Candy(
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
