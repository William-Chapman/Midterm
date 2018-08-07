using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Midterm
{
    static class Payment
    {
        #region Properties
        public static double SubTotal { set; get; }
        public static double SalesTax { set; get; }
        public static double GrandTotal { set; get; }
        #endregion

        #region Methods

        public static void DisplayReceipt(List<Product> cart, Credit userPayment)
        {
            //for loop to display the items they bought
            foreach (Product item in cart)
            {
                Console.WriteLine($"{item.Name,-30} {item.Category,-15} {item.Description,-35} {String.Format($"{item.Price:c}"),-15} {item.Quantity}");
            }
            //display totals
            Console.WriteLine(SubTotal);
            Console.WriteLine(SalesTax);
            Console.WriteLine(GrandTotal);
            //display payment option information
            Console.Write("xxxx-xxxx-xxxx-");
            Console.Write(userPayment.CardNum[userPayment.CardNum.Length - 1]);
            Console.Write(userPayment.CardNum[userPayment.CardNum.Length - 2]);
            Console.Write(userPayment.CardNum[userPayment.CardNum.Length - 3]);
            Console.WriteLine(userPayment.CardNum[userPayment.CardNum.Length - 4]);
            Console.WriteLine(userPayment.ExpDate);
        }

        public static void ValidatePaymentType()
        {
            bool valid = false;


            do
            {
                //ask how they will be paying and gather response in the userPayment string
                Console.WriteLine("\nHow will you be paying today? Cash, check or credit?");
                string userPayment = Console.ReadLine();

                if (userPayment.ToLower() == "cash" || userPayment.ToLower() == "check" || userPayment.ToLower() == "credit")
                {
                    if (userPayment.ToLower() == "cash")
                    {
                        //if they responded cash, call takecash
                        Payment.TakeCash();
                    }

                    if (userPayment.ToLower() == "check")
                    {
                        //if they responded check, call takecheck
                        Payment.TakeCheck();
                    }

                    if (userPayment.ToLower() == "credit")
                    {
                        //if they responded credit, call take credit
                        Payment.TakeCredit();
                    }

                    valid = true;
                }
                else
                {
                    //if they did not enter a valid response, call them out on that shit
                    Console.WriteLine("Please enter a valid response.");
                    valid = false;
                }
            }
            while (!valid);
        }

        public static Cash TakeCash()
        {
            string amount;
            double validAmount;
            bool valid = true;

            Cash payment = new Cash();

            do
            {
                //gather the amount they are paying with in amount
                Console.WriteLine("Please enter the amount you are paying with.");
                amount = Console.ReadLine();

                if (double.TryParse(amount, out validAmount))
                {
                    //if amount can be parsed, set the object values
                    payment.AmountGiven = validAmount;
                    payment.Change = payment.GetChange(GrandTotal);
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
            return payment;
        }

        public static Check TakeCheck()
        {
            string amount;
            double validAmount;
            bool valid = true;

            Check payment = new Check();

            do
            {
                //Ask how much the check is for and store it in amount
                Console.WriteLine("Please enter the amount the check is for.");
                amount = Console.ReadLine();

                if (double.TryParse(amount, out validAmount))
                {
                    //if amount can be parsed set the object values
                    payment.AmountGiven = validAmount;
                    Console.WriteLine("Please enter the check number");
                    payment.CheckNum = Console.ReadLine();
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
            return payment;
        }

        public static Credit TakeCredit()
        {
            string cardNum;
            string cardPattern = @"^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$";
            string expDate;
            string expPattern = @"^[0-9]{2}/[0-9]{2}$";
            string cvv;
            string cvvPattern = @"^[0-9]{3}$";
            bool valid = false;

            Credit payment = new Credit();
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
                    payment.CardNum = cardNum;
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
                    payment.ExpDate = expDate;
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
                    payment.CVV = cvv;
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
            return payment;
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
