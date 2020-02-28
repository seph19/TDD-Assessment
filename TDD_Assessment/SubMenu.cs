using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_Assessment
{
    public class SubMenu
    {
        private VendingMachine vm;

        public SubMenu(VendingMachine vm)
        {
            this.vm = vm;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Please choose from the following options:");
                Console.WriteLine("1] >> Feed Money");
                Console.WriteLine("2] >> Select Product");
                Console.WriteLine("3] >> Finish Transaction");
                Console.WriteLine("4] >> Refund Item");
                Console.WriteLine("Q] >> Return to Main Menu");
                Console.WriteLine($"Money in Machine: {this.vm.MoneyInMachine.ToString("C")}");
                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine(">>> How much do you want to insert?");
                    while (true)
                    {
                        Console.Write("0.25, 0.50, 1, 2, 5, 10, 25, 50,100 dollars? ");
                        string amountToSubmit = Console.ReadLine();
                        if (amountToSubmit == "0.25"
                            || amountToSubmit == "0.50"
                            || amountToSubmit == "1"
                            || amountToSubmit == "5"
                            || amountToSubmit == "10"
                            || amountToSubmit == "25"
                            || amountToSubmit == "50"
                            || amountToSubmit == "100")
                        {
                            if (!this.vm.Money.AddMoney(amountToSubmit))
                            {
                                Console.WriteLine("Insert a valid amount.");
                            }
                            else
                            {
                                Console.WriteLine($"Money in Machine: {this.vm.Money.MoneyInMachine.ToString("C")}");
                                break;
                            }
                        }
                    }

                }
                else if (input == "2")
                {
                    while (true)
                    {
                        var products = vm.DisplayAllItems();
                        foreach (var product in products)
                        {
                            Console.WriteLine($"{product.itemNumber} {product.itemsRemaining} {product.productName} Costs: {product.price} each");
                        }
                        Console.Write(">>> What item do you want (#)? ");
                        string choice = Console.ReadLine();

                        if (this.vm.ItemExists(choice) && vm.RetreiveItem(choice))
                        {
                            Console.WriteLine($"Enjoy your {vm.VendingMachineItems[choice].ProductName}\n{this.vm.VendingMachineItems[choice].MessageWhenVended}");
                            break;
                        }
                        else if (!this.vm.ItemExists(choice))
                        {
                            Console.Clear();
                            Console.WriteLine("**INVALID ITEM**");
                        }
                        else if (this.vm.ItemExists(choice) && this.vm.Money.MoneyInMachine > this.vm.VendingMachineItems[choice].Price)
                        {
                            Console.WriteLine(this.vm.VendingMachineItems[choice].MessageWhenSoldOut);
                        }
                        else if (this.vm.Money.MoneyInMachine < vm.VendingMachineItems[choice].Price)
                        {
                            Console.WriteLine(this.vm.NotEnoughMoneyError);
                            break;
                        }
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Finishing Transaction");
                    Console.WriteLine(this.vm.Money.GiveChange());
                }
                else if (input == "4")
                {
                    this.vm.DisplayAllItems();
                    Console.Write(">>> What item do you want to refund (#)? ");
                    string choice = Console.ReadLine();

                    if (this.vm.ItemExists(choice))
                    {
                        this.vm.Money.AddMoney(this.vm.VendingMachineItems[choice].Price.ToString());
                        this.vm.VendingMachineItems[choice].AddItem();
                        Console.WriteLine("Item refunded!");
                        Console.WriteLine($"Money in Machine: {this.vm.Money.MoneyInMachine.ToString("C")}");
                    }
                    else if (!this.vm.ItemExists(choice))
                    {
                        Console.Clear();
                        Console.WriteLine("**INVALID ITEM**");
                    }

                }
                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Returning to main menu");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }

                Console.ReadLine();
            }
        }
    }
}
