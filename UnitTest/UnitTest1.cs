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
    }
}
