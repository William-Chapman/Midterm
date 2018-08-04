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

        public string ValidatePaymentType(string userPayment)
        {
            if(userPayment.ToLower() == "cash")
            {
                return "cash";
            }
            else if(userPayment.ToLower() == "check")
            {
                return "check";
            }
            else if(userPayment.ToLower() == "credit")
            {
                return "credit";
            }
            else
            {
                return "none";
            }
        }

        public void CalculateGT()
        {

        }

        public double CalculateSuTo(int quantity, double itemPrice)
        {
            double subTotal = quantity * itemPrice;
            return subTotal;
        }

        public double CalculateTax(double subTotal)
        {
            double totalTax = subTotal * 0.06d;
            return totalTax;
        }
        #endregion
    }
}
