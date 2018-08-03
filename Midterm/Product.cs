using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Product
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

        public string Descriptioin
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
            name = nam;
            category = cate;
            description = des;
            price = pri;
            quantity = quan;

        }
        // default constructor
        public Product()
        {

        }

        // method
        public virtual void ListManager()
        {
            Console.WriteLine($"{Name}\t{Category}\t{Descriptioin}\t{Price:c}\t{Quantity}");

        }


    }
}
