namespace Midterm
{
    class Produce : Product
    {

        // Produce class inheriting from the base class Product


        private bool organic; // field

        public bool Organic // properties
        {
            set { organic = value; }
            get { return organic; }
        }

        // constructor with parameters
        public Produce(string nam, string cate, string des, double pri, int quan, bool org) : base(nam, cate, des, pri, quan) // inheritance
        {
            organic = org;
        }
        // default constructor
        public Produce()
        {

        }
        // method overriding base class method Product
        //public override void Product()
        //{
        //    base.product(); // calls code from the top
        //    Console.WriteLine($"Organic {Organic}");
        //}
    }
}
