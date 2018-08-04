using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    /// Soda class inheriting from the base class Product
    class Soda : Product
    {

        private bool diet;

        public bool Diet
        {
            set { diet = value; }
            get { return diet; }
        }

        // constructor with parameters
        public Soda(string nam, string cate, string des, double pri, int quan, bool di) : base(nam, cate, des, pri, quan) // inheritance
        {
            diet = di;
        }
        // default constructor
        public Soda()
        {

        }

        //method overriding base class method Product
        //public override void Product()
        //{
        //    base.Product(); // calls code from the top
        //    Console.WriteLine($"Diet {Diet}");


        //}
    }
}
