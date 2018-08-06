using System;

namespace Midterm
{
    static class Payment
    {
        #region Constructors
        public static double SubTotal { set; get; }
        public static double SalesTax { set; get; }
        public static double GrandTotal { set; get; }
        #endregion

        #region Methods
        public static void DisplayReceipt()
        {

        }

        public static string ValidatePaymentType()
        {
            //ask the user how they will be paying
            Console.WriteLine("How will you be paying today? Cash, Check or Credit?");
            string userPayment = Console.ReadLine();

            if (userPayment.ToLower() == "cash" || userPayment.ToLower() == "check" || userPayment.ToLower() == "credit")
            {
                //if what they input is a valid option, return what they input
                return userPayment;
            }
            else
            {
                //if what they input is not a valid option, return the word "none"
                return "none";
            }
        }

        public static double CalculateGT(double subTotal, double totalTax)
        {
            //take the subtotal and add the total tax, return grandtotal
            double grandTotal = subTotal + totalTax;
            return grandTotal;
        }

        public static double CalculateSuTo(int quantity, double itemPrice)
        {
            //take the quantity and times it by the item's price, return subtotal
            double subTotal = quantity * itemPrice;
            return subTotal;
        }

        public static double CalculateTax(double subTotal)
        {
            //take the subtotal and times it by the sales tax rate, return the total tax
            double totalTax = subTotal * 0.06d;
            return totalTax;
        }
        #endregion
    }
}
