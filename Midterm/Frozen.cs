using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Frozen : Product
    {
        // Soda class inheriting from the base class Product


        private bool dessert;

        public bool Dessert
        {
            set { dessert = value; }
            get { return dessert; }
        }

        // constructor with parameters
        public Frozen(string nam, string cate, string des, double pri, int quan, bool dess) : base(nam, cate, des, pri, quan) // inheritance
        {
            dessert = dess;
        }
        // default constructor
        public Frozen()
        {

        }
        //method overriding base class method Product
        //public override void Product()
        //{
        //   base.product(); // calls code from the top
        //   Console.WriteLine($"Dessert {Dessert}");
    }

}
