using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Product> productList = new List<Product>(); // Makes Product List
            List<Product> cartList = new List<Product>(); // Makes Cart List

            // ***INPUT***

            StreamReader reader = new StreamReader("../../Products.txt", true);
            List<string> stringList = new List<string>();
            string fileData = "";
            string nextLine = reader.ReadLine();

            while (nextLine != null)
            {
                fileData += nextLine + "\n";
                stringList.Add(nextLine);
                nextLine = reader.ReadLine();
            }

            foreach (string product in stringList)
            {
                string[] info = product.Split(',');

                Product temp = new Product(info[0], info[1], info[2], double.Parse(info[3]), Int32.Parse(info[4]));
                productList.Add(temp);
            }

            reader.Close();

            // ***OUTPUT***
            PrintHeader(); // ----------- prints header display
            PrintList(productList); // -------prints productList
            AddToCart(productList, cartList); // ------adds user selection to cart & displays current cart items w/price
            PaymentOptions(cartList); // ---------takes user payment type and prints receipt

        }

        private static void PaymentOptions(List<Product> cartList)
        {
            bool valid = false;
            do
            {
                //ask how they will be paying and gather response in the userPayment string
                Console.Write("\nHow will you be paying today? Cash, Check or Credit? ");
                string userPayment = Console.ReadLine();

                if (userPayment.ToLower() == "cash")
                {
                    Cash userCash = new Cash();
                    foreach (Product item in cartList)
                    {
                        double sub = userCash.CalculateSuTo(item.Quantity, item.Price);
                        double tax = userCash.CalculateTax(sub);
                        double grand = userCash.CalculateGT(sub, tax);
                    }
                    userCash = userCash.TakeCash(userCash);
                    userCash.DisplayCashReceipt(cartList, userCash);
                    valid = true;
                }
                else if (userPayment.ToLower() == "check")
                {
                    Check userCheck = new Check();
                    foreach (Product item in cartList)
                    {
                        double sub = userCheck.CalculateSuTo(item.Quantity, item.Price);
                        double tax = userCheck.CalculateTax(sub);
                        double grand = userCheck.CalculateGT(sub, tax);
                    }
                    userCheck = userCheck.TakeCheck(userCheck);
                    userCheck.DisplayCheckReceipt(cartList, userCheck);
                    valid = true;
                }
                else if (userPayment.ToLower() == "credit")
                {
                    Credit userCredit = new Credit();
                    foreach (Product item in cartList)
                    {
                        double sub = userCredit.CalculateSuTo(item.Quantity, item.Price);
                        double tax = userCredit.CalculateTax(sub);
                        double grand = userCredit.CalculateGT(sub, tax);
                    }
                    userCredit = userCredit.TakeCredit(userCredit);
                    userCredit.DisplayCreditReceipt(cartList, userCredit);
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid response.");
                    valid = false;
                }
            }
            while (!valid);
        }

        private static void PrintHeader()
        {
            string dItem = "Item";
            string dCategory = "Category";
            string dDescription = "Description";
            string dPrice = "Price";
            string dQuantity = "Quantity";

            Console.WriteLine("***Welcome to BDW\'s Marketplace***\n");
            Console.WriteLine($"{dItem,-30} {dCategory,-15} {dDescription,-35} {dPrice,-15} {dQuantity,10}/Box (In Stock)");
            Console.WriteLine("============================================================================================================================\n");
        }

        private static void AddToCart(List<Product> productList, List<Product> cartList)
        {
            bool repeat = true;
            while (repeat)
            {

                Console.WriteLine("\nWhat item would you like to have added to your cart? (Enter item name)");
                string userInput = ValidateUserInput(Console.ReadLine());

                foreach (Product item in productList)
                {

                    if (userInput.ToLower() == item.Name.ToLower())
                    {
                        Console.WriteLine($"\nYou've selected {item.Name}, it will be added to your cart.");
                        Console.WriteLine($"How many boxes of {item.Name} would you like to add to your cart?");
                        item.Quantity = Int32.Parse(Console.ReadLine());
                        cartList.Add(item);

                        Console.WriteLine("\nWould you like to add another item to your cart? (enter y or n)");
                        string userResponse = Console.ReadLine().ToLower();

                        if (userResponse == "y" || userResponse == "yes")
                        {
                            repeat = true;
                            Console.Clear();
                            PrintHeader();
                            PrintList(productList);


                        }
                        else if (userResponse == "n" || userResponse == "no")
                        {
                            repeat = false;
                            Console.Clear();
                            Console.WriteLine("\nCurrently you have these items in your cart: ");
                            Console.WriteLine("\n\t***Your Shopping Cart***\n-------------------------------------------------");

                            double subTotal = 0;


                            foreach (Product cart in cartList)  // foreach (Product e in carList)
                            {
                                subTotal += cart.Quantity * cart.Price;
                                Console.WriteLine(String.Format($"{cart.Name,-30} {cart.Quantity} x {(cart.Price) * (cart.Quantity):c}"));
                            }
                            double totalTax = subTotal * 0.06d;
                            double grandTotal = subTotal + totalTax;

                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine($"Subtotal: {subTotal:c}");
                            Console.WriteLine($"Sales Tax: {totalTax:c}");
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine($"Grand Total: {grandTotal:c}");

                            break;

                        }
                        else
                        {
                            Console.WriteLine("Input not valid. Please try again.");
                            repeat = true;
                        }
                    }

                }
            }
        }

        private static void PrintList(List<Product> productList)
        {
            foreach (Product item in productList)
            {
                item.PrintList(productList);
            }
        }

        public static string ValidateUserInput(string userInput)
        {
            // Validates userInput
            if (!Regex.IsMatch(userInput, @"^[a-zA-z ]{1,30}$"))
            {
                throw new Exception("Invalid input. Please try again");
            }

            return userInput;
        }






    }
}