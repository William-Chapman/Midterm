using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Payment
    {
        #region Constructors
        public double SubTotal { set; get; }
        public double SalesTax { set; get; }
        public double GrandTotal { set; get; }
        #endregion

        #region Methods
        public void DisplayReceipt()
        {

        }

        public string ValidatePaymentType()
        {
            //ask the user how they will be paying
            Console.WriteLine("How will you be paying today? Cash, check or credit?");
            string userPayment = Console.ReadLine();

            if(userPayment.ToLower() == "cash" || userPayment.ToLower() == "check" || userPayment.ToLower() == "credit")
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

        public double CalculateGT(double subTotal, double totalTax)
        {
            //take the subtotal and add the total tax, return grandtotal
            double grandTotal = subTotal + totalTax;
            return grandTotal;
        }

        public double CalculateSuTo(int quantity, double itemPrice)
        {
            //take the quantity and times it by the item's price, return subtotal
            double subTotal = quantity * itemPrice;
            return subTotal;
        }

        public double CalculateTax(double subTotal)
        {
            //take the subtotal and times it by the sales tax rate, return the total tax
            double totalTax = subTotal * 0.06d;
            return totalTax;
        }
        #endregion
    }
}
