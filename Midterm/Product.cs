using System;
using System.Collections.Generic;

namespace Midterm
{
    class Product : Program
    {

        // fields

        private string name;
        private string description;
        private string category;
        private double price;
        private int quantity;


        // properties
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Description
        {
            set { description = value; }
            get { return description; }
        }

        public string Category
        {
            set { category = value; }
            get { return category; }
        }

        public double Price
        {
            set { price = value; }
            get { return price; }
        }
        public int Quantity
        {
            set { quantity = value; }
            get { return quantity; }
        }


        // constructor that initialize the class with parameters
        public Product(string nam, string cate, string des, double pri, int quan)
        {
            Name = nam;
            Category = cate;
            Description = des;
            Price = pri;
            Quantity = quan;

        }
        // default constructor
        public Product()
        {

        }

        // method
        public virtual void PrintList(List<Product> productList)
        {
            Console.WriteLine($"{Name,-30} {Category,-15} {Description,-35} {String.Format($"{Price:c}"),-15} {Quantity}");

        }


    }
}
