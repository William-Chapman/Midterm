using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Midterm
{
    class Payment
    {
        #region Properties
        public static double SubTotal { set; get; }
        public static double SalesTax { set; get; }
        public static double GrandTotal { set; get; }
        #endregion


        #region Methods

        public static void TotalAmountDue()
        {
            Console.WriteLine(String.Format($"SubTotal: {SubTotal:c}"), -15);
            Console.WriteLine($"Sales Tax (6%): {SalesTax:c}");
            Console.WriteLine($"Grand Total: {GrandTotal:c}");
        }

        public void DisplayCheckReceipt(List<Product> cart, Check userPayment)
        {
            Console.WriteLine("\n\t*****Receipt*****");

            //for loop to display the items they bought
            foreach (Product item in cart)
            {
                Console.WriteLine($"{item.Name,-30} {String.Format($"{item.Price:c}"),-15}");
            }
            //display totals
            TotalAmountDue();
            //display payment option information
            Console.WriteLine($"Check Number: {userPayment.CheckNum}");
            Console.WriteLine($"{userPayment.AmountGiven:c}");
        }

        public void DisplayCashReceipt(List<Product> cart, Cash userPayment)
        {
            Console.WriteLine("\n\t*****Receipt*****");

            //for loop to display the items they bought
            foreach (Product item in cart)
            {
                Console.WriteLine($"{item.Name,-30} {String.Format($"{item.Price:c}"),-15}");
            }
            Console.WriteLine("-------------------------------------------------");
            //display totals
            TotalAmountDue();
            //display payment option information
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Amount Paid: {userPayment.AmountGiven:c}");
            Console.WriteLine($"Change: {userPayment.Change:c}");
        }

        public void DisplayCreditReceipt(List<Product> cart, Credit userPayment)
        {
            Console.WriteLine("\n*****Receipt*****");

            //for loop to display the items they bought
            foreach (Product item in cart)
            {
                Console.WriteLine($"{item.Name,-30} {String.Format($"{item.Price:c}"),-15}");
            }
            //display totals
            TotalAmountDue();
            //display payment option information
            Console.Write("xxxx-xxxx-xxxx-");
            Console.Write(userPayment.CardNum[userPayment.CardNum.Length - 1]);
            Console.Write(userPayment.CardNum[userPayment.CardNum.Length - 2]);
            Console.Write(userPayment.CardNum[userPayment.CardNum.Length - 3]);
            Console.WriteLine(userPayment.CardNum[userPayment.CardNum.Length - 4]);
        }

        public Cash TakeCash(Cash userCash)
        {
            string amount;
            double validAmount;
            bool valid = true;

            do
            {
                //gather the amount they are paying with in amount
                Console.WriteLine("Please enter the amount you are paying with.");
                amount = Console.ReadLine();

                if (double.TryParse(amount, out validAmount))
                {
                    //if amount can be parsed, set the object values
                    userCash.AmountGiven = validAmount;
                    userCash.Change = userCash.GetChange(GrandTotal);
                    valid = true;
                }
                else
                {
                    //if amount cannot be parsed, tell the user to try again
                    Console.WriteLine("Please enter a valid number.");
                    valid = false;
                }
            }
            while (!valid);
            return userCash;
        }

        public Check TakeCheck(Check userCheck)
        {
            string amount;
            double validAmount;
            bool valid = true;

            do
            {
                //Ask how much the check is for and store it in amount
                Console.WriteLine("Please enter the amount the check is for.");
                amount = Console.ReadLine();

                if (double.TryParse(amount, out validAmount))
                {
                    //if amount can be parsed set the object values
                    userCheck.AmountGiven = validAmount;
                    Console.WriteLine("Please enter the check number");
                    userCheck.CheckNum = Console.ReadLine();
                    valid = true;
                }
                else
                {
                    //if amount cannot be parsed, tell user to try again
                    Console.WriteLine("Please enter a valid amount.");
                    valid = false;
                }
            }
            while (!valid);
            return userCheck;
        }

        public Credit TakeCredit(Credit userCredit)
        {
            string cardNum;
            string cardPattern = @"^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$";
            string expDate;
            string expPattern = @"^[0-9]{2}/[0-9]{2}$";
            string cvv;
            string cvvPattern = @"^[0-9]{3}$";
            bool valid = false;

            Regex cardRgx = new Regex(cardPattern);
            Regex expRgx = new Regex(expPattern);
            Regex cvvRgx = new Regex(cvvPattern);

            do
            {
                //ask the user for the card number, store it in cardNum
                Console.WriteLine("Please enter the card number. (xxxx-xxxx-xxxx-xxxx)");
                cardNum = Console.ReadLine();

                if (cardRgx.IsMatch(cardNum))
                {
                    //if the card number matches the pattern, set object value
                    userCredit.CardNum = cardNum;
                    valid = true;
                }
                else
                {
                    //if not, ask them to try again
                    Console.WriteLine("Please enter a valid card number.");
                    valid = false;
                }
            }
            while (!valid);

            do
            {
                //ask the user for the expiration date
                Console.WriteLine("Please enter the expiration date. (xx/xx)");
                expDate = Console.ReadLine();
                if (expRgx.IsMatch(expDate))
                {
                    //if it matches the pattern, set object value
                    userCredit.ExpDate = expDate;
                    valid = true;
                }
                else
                {
                    //if not, try again
                    Console.WriteLine("Please enter a valid expiration date.");
                    valid = false;
                }
            }
            while (!valid);

            do
            {
                //ask user for cvv
                Console.WriteLine("Please enter your card's CVV.");
                cvv = Console.ReadLine();
                if (cvvRgx.IsMatch(cvv))
                {
                    //if it matches, set object value
                    userCredit.CVV = cvv;
                    valid = true;
                }
                else
                {
                    //if not, tell em to shove it
                    Console.WriteLine("Please enter a valid CVV.");
                    valid = false;
                }
            }
            while (!valid);
            return userCredit;
        }

        public double CalculateGT(double subTotal, double totalTax)
        {
            //take the subtotal and add the total tax, return grandtotal
            double grandTotal = subTotal + totalTax;
            GrandTotal += grandTotal;
            return grandTotal;
        }

        public double CalculateSuTo(int quantity, double itemPrice)
        {
            //take the quantity and times it by the item's price, return subtotal
            double subTotal = quantity * itemPrice;
            SubTotal += subTotal;
            return subTotal;
        }

        public double CalculateTax(double subTotal)
        {
            //take the subtotal and times it by the sales tax rate, return the total tax
            double totalTax = subTotal * 0.06d;
            SalesTax += totalTax;
            return totalTax;
        }
        #endregion
    }
}
