using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> productList = new List<Product>(); // Makes Product List

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
            Product sodaDrPepper = new Product("Dr. Pepper", "Soda", "16 oz.", 2.49, 87);
            Product sodaSprite = new Product("Sprite", "Soda", "16 oz.", 2.49, 64);
            Product sodaCoke = new Product("Coke", "Soda", "16 oz.", 2.49, 98);
            #endregion

            #region Diet Soda
            Product sodaDietPepsi = new Product("Diet Pepsi", "Diet Soda", "16 oz.", 2.49, 53);
            Product sodaDietDrPepper = new Product("Diet Dr.Pepper", "Diet Soda", "16 oz.", 2.49, 61);
            Product sodaDietSprite = new Product("Diet Sprite", "Diet Soda", "16 oz.", 2.49, 24);
            Product sodaDietCoke = new Product("Diet Coke", "Diet Soda", "16 oz.", 2.49, 68);
            #endregion

            #region Frozen Food
            Product frozen1 = new Product("Frozon Corn", "Frozen Food", "16 oz.", 2.49, 45);
            Product frozen2 = new Product("Frozon Mixed Vegetables", "Frozen Food", "16 oz.", 2.49, 40);
            Product frozen3 = new Product("Frozon Broccoli", "Frozen Food", "16 oz.", 2.49, 70);
            Product frozen4 = new Product("Frozon Green Beans", "Frozen Food", "16 oz.", 2.49, 79);
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
            productList.Add(sodaDrPepper);
            productList.Add(sodaSprite);
            #endregion

            #region Add Diet Soda
            productList.Add(sodaDietPepsi);
            productList.Add(sodaDietCoke);
            productList.Add(sodaDietDrPepper);
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

            // -------prints productList
            foreach (Product item in productList)
            {
                item.PrintList(productList);
            }
            Console.WriteLine();

            Console.WriteLine("What item would you like to add your cart?");
            ValidateUserInput();



        }

        // ***METHOD***
        public static void ValidateUserInput()
        {
            string userInput = Console.ReadLine();

            if (!Regex.IsMatch(userInput, @"^[a-zA-z ]{1,20}$"))
            {
                throw new Exception("Invalid input. Please try again");
            }
        }






    }
}
