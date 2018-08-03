using System;
using System.Collections.Generic;

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
            Product pChicken = new Product();
            Product pPork = new Product();
            Product pBeef = new Product();
            Product pShrimp = new Product();
            #endregion

            #region Organic Produce
            Product orgChicken = new Product();
            Product orgPork = new Product();
            Product orgBeef = new Product();
            Product orgShrimp = new Product();
            #endregion

            #region Soda
            Product sodaPepsi = new Product();
            Product sodaDrPepper = new Product();
            Product sodaSprite = new Product();
            Product sodaCoke = new Product();
            #endregion

            #region Diet Soda
            Product sodaDietPepsi = new Product();
            Product sodaDietDrPepper = new Product();
            Product sodaDietSprite = new Product();
            Product sodaDietCoke = new Product();
            #endregion

            #region Frozen Food
            Product frozen1 = new Product();
            Product frozen2 = new Product();
            Product frozen3 = new Product();
            Product frozen4 = new Product();
            #endregion

            #region Dessert
            Product dessert1 = new Product();
            Product dessert2 = new Product();
            Product dessert3 = new Product();
            Product dessert4 = new Product();
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
            string dItem = "Items";
            string dPrice = "Price";

            Console.WriteLine($"{dItem,-20} {dPrice}");
            Console.WriteLine("================================");









        }



    }
}
