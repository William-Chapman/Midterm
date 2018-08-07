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
            Console.WriteLine("***Welcome to BDW\'s Marketplace***\n");


            // ***PROCESSING***

            // ProductList   
            #region Produce
            Product pChicken = new Product("Chicken Breast", "Poultry", "Fresh Chicken Breast", 3.99, 12);
            Product pPork = new Product("Bacon", "Pork", "Applewood", 4.99, 3);
            Product pBeef = new Product("Beef Tips", "Beef", "Smoked", 5.99, 7);
            Product pShrimp = new Product("Jumbo Shrimp", "Seafood", "Large Shrimp", 4.99, 28);
            #endregion

            #region Organic Produce
            Product orgChicken = new Product("Rotisserie Chicken", "Poultry", "(Organic) Roteisserie Chicken", 12.99, 56);
            Product orgPork = new Product("Pork Chops", "Pork", "(Organic) Smoked Pork Chops", 10.99, 38);
            Product orgBeef = new Product("Beef Steaks", "Beef", "(Organic) Baked Beef Steaks", 12.99, 42);
            Product orgShrimp = new Product("Jumbo Shrimp", "Seafood", "(Organic) Large Shrimp", 6.99, 52);
            #endregion

            #region Soda
            Product sodaPepsi = new Product("Pepsi", "Soda", "16 oz.", 2.49, 32);
            Product sodaMountainDew = new Product("Mountain Dew", "Soda", "16 oz.", 2.49, 87);
            Product sodaSprite = new Product("Sprite", "Soda", "16 oz.", 2.49, 64);
            Product sodaCoke = new Product("Coke", "Soda", "16 oz.", 2.49, 98);
            #endregion

            #region Diet Soda
            Product sodaDietPepsi = new Product("Diet Pepsi", "Diet Soda", "16 oz.", 2.49, 53);
            Product sodaDietMountainDew = new Product("Diet Mountain Dew", "Diet Soda", "16 oz.", 2.49, 61);
            Product sodaDietSprite = new Product("Diet Sprite", "Diet Soda", "16 oz.", 2.49, 24);
            Product sodaDietCoke = new Product("Diet Coke", "Diet Soda", "16 oz.", 2.49, 68);
            #endregion

            #region Frozen Food
            Product frozen1 = new Product("Frozen Corn", "Frozen Food", "16 oz.", 2.49, 45);
            Product frozen2 = new Product("Frozen Mixed Vegetables", "Frozen Food", "16 oz.", 2.49, 40);
            Product frozen3 = new Product("Frozen Broccoli", "Frozen Food", "16 oz.", 2.49, 70);
            Product frozen4 = new Product("Frozen Green Beans", "Frozen Food", "16 oz.", 2.49, 79);
            #endregion

            #region Dessert
            Product dessert1 = new Product("Oreo Cheesecake", "Dessert", "Oreo Flavored Cheesecake", 8.99, 41);
            Product dessert2 = new Product("Hot Fudge Sunday", "Dessert", "Ice Cream w/ Hot Fudge", 5.49, 56);
            Product dessert3 = new Product("Carmel Apple Pie", "Dessert", "Apple pie slice w/ carmel syrup", 3.49, 35);
            Product dessert4 = new Product("Ice Cream Sandwhich Bar", "Dessert", "Ice Sandwhich", 1.49, 51);
            #endregion

            // add products to list

            #region Add Produce
            productList.Add(pChicken);
            productList.Add(pPork);
            productList.Add(pBeef);
            productList.Add(pShrimp);
            #endregion

            #region Add Organic Produce
            productList.Add(orgChicken);
            productList.Add(orgBeef);
            productList.Add(orgPork);
            productList.Add(orgShrimp);
            #endregion

            #region Add Soda
            productList.Add(sodaCoke);
            productList.Add(sodaPepsi);
            productList.Add(sodaMountainDew);
            productList.Add(sodaSprite);
            #endregion


            #region Add Diet Soda
            productList.Add(sodaDietPepsi);
            productList.Add(sodaDietCoke);
            productList.Add(sodaDietMountainDew);
            productList.Add(sodaDietSprite);
            #endregion

            #region Add Frozen Food
            productList.Add(frozen1);
            productList.Add(frozen2);
            productList.Add(frozen3);
            productList.Add(frozen4);
            #endregion

            #region Add Dessert
            productList.Add(dessert1);
            productList.Add(dessert2);
            productList.Add(dessert3);
            productList.Add(dessert4);
            #endregion 



            // ***OUTPUT***
            string dItem = "Item";
            string dCategory = "Category";
            string dDescription = "Description";
            string dPrice = "Price";
            string dQuantity = "Quantity";

            Console.WriteLine($"{dItem,-30} {dCategory,-15} {dDescription,-35} {dPrice,-15} {dQuantity,10}/Box (In Stock)");
            Console.WriteLine("============================================================================================================================\n");

            PrintList(productList); // -------prints productList
            AddToCart(productList, cartList); // ------adds user selection to cart & displays current cart items w/price\

            
            bool valid = false;
            do
            {
                //ask how they will be paying and gather response in the userPayment string
                Console.WriteLine("How will you be paying today? Cash, check or credit?");
                string userPayment = Console.ReadLine();

                if (userPayment.ToLower() == "cash")
                {
                    Cash userCash = new Cash();
                    foreach (Product item in cartList)
                    {
                        double sub = userCash.CalculateSuTo(1, item.Price);
                        double tax = userCash.CalculateTax(sub);
                        double grand = userCash.CalculateGT(sub, tax);
                    }
                    userCash = userCash.TakeCash(userCash);
                    userCash.DisplayReceipt(cartList, userCash);
                    valid = true;
                }
                else if (userPayment.ToLower() == "check")
                {
                    Check userCheck = new Check();
                    foreach (Product item in cartList)
                    {
                        double sub = userCheck.CalculateSuTo(1, item.Price);
                        double tax = userCheck.CalculateTax(sub);
                        double grand = userCheck.CalculateGT(sub, tax);
                    }
                    userCheck = userCheck.TakeCheck(userCheck);
                    userCheck.DisplayReceipt(cartList, userCheck);
                    valid = true;
                }
                else if (userPayment.ToLower() == "credit")
                {
                    Credit userCredit = new Credit();
                    foreach (Product item in cartList)
                    {
                        double sub = userCredit.CalculateSuTo(1, item.Price);
                        double tax = userCredit.CalculateTax(sub);
                        double grand = userCredit.CalculateGT(sub, tax);
                    }
                    userCredit = userCredit.TakeCredit(userCredit);
                    userCredit.DisplayReceipt(cartList, userCredit);
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
                        cartList.Add(item);

                        Console.WriteLine("\nWould you like to add another item to your cart? (enter y or n)");
                        string userResponse = Console.ReadLine().ToLower();

                        if (userResponse == "y" || userResponse == "yes")
                        {
                            PrintList(productList);
                            repeat = true;

                        }
                        else if (userResponse == "n" || userResponse == "no")
                        {
                            repeat = false;
                            Console.WriteLine("\nCurrently you have these items in your cart: \n");
                            Console.WriteLine("\n\t***Your Shopping Cart***\n---------------------------------------");

                             StreamWriter wr = new StreamWriter("../../data.txt", false);
                            foreach (Product cart in cartList)  // foreach (Product e in carList)
                            {
                                wr.WriteLine(String.Format($"{cart.Name,-30} {cart.Price:c}"));
                               
                            }
                            wr.Close();
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