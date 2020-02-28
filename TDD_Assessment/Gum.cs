using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_Assessment
{
    public class Gum : VendingItem
    {
        public const string Message = "Thanks for buying!";

        public Gum(
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
