using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Linq;
using TDD_Assessment;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [DataTestMethod]
        [DataRow("100", 100)]
        [DataRow("50", 50)]
        [DataRow("25", 25)]
        [DataRow("10", 10)]
        [DataRow("5", 5)]
        [DataRow("1", 1)]
        [DataRow("0.50", 0.50)]
        [DataRow("0.25", 0.25)]
        public void When_NotEnough_BillEntered_ToBuyItem(string input, double expected)
        {
            VendingMachine vm = new VendingMachine();
            vm.Money.AddMoney(input);
            decimal result = vm.Money.MoneyInMachine;

            Assert.AreEqual((decimal)expected, result);
        }

        [TestMethod]
        public void TestsIfNotEnoughMoneyEnteredToPurchaseItem()
        {
            VendingMachine vm = new VendingMachine();
            vm.RetreiveItem("A1");
            string result = vm.NotEnoughMoneyError;
            Assert.AreEqual("Not enough money in the machine to complete the transaction.", result);
        }

        [TestMethod]

        public void TestsIfReturnCashAsExpected()
        {
            VendingMachine vm = new VendingMachine();
            vm.Money.AddMoney("1.35");
            string result = vm.Money.GiveChange();

            Assert.AreEqual(result, "Your change is 5 quarters and 1 dimes");

        }

        [TestMethod]
        public void When_Selecting_Products()
        {
            VendingMachine vm = new VendingMachine();

            var products = vm.DisplayAllItems();

            Assert.AreEqual(typeof(List<Product>), products.GetType());
        }

        [DataTestMethod]
        [DataRow("1", "Coke", 25)]
        [DataRow("2", "Pepsi", 35)]
        [DataRow("3", "Soda", 45)]
        [DataRow("4", "Bottled water", 15)]
        [DataRow("5", "chocolate bar", 20.25)]
        [DataRow("6", "Chewing gum", 10.25)]
        public void When_Selecting_Products(string itemNumber, string productName, double amount)
        {
            VendingMachine vm = new VendingMachine();

            var result = vm.ItemExists(itemNumber);

            Assert.AreEqual(true, result);
        }

        [DataTestMethod]
        [DataRow("1", "Coke", "25", "$25.00")]
        [DataRow("2", "Pepsi", "35", "$35.00")]
        [DataRow("3", "Soda", "45", "$45.00")]
        [DataRow("4", "Bottled water", "15", "$15.00")]
        [DataRow("5", "chocolate bar", "20.25", "$20.25")]
        [DataRow("6", "Chewing gum", "10.25", "$10.25")]
        public void When_CancelingItem_SelectProductToCancel_TO_Have_Refund(string itemNumber, string productName, string amount,string expectedAmount)
        {
            VendingMachine vm = new VendingMachine();

            var result = vm.Money.AddMoney(amount);

            var results = vm.Money.MoneyInMachine.ToString("C");

            Assert.AreEqual(expectedAmount, results);
        }

    }
}
