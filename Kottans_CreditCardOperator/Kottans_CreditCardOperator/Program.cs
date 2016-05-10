using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kottans_CreditCardOperator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your credit card number here: ");
            string input = Console.ReadLine();
            string goodInput = input.Trim().Replace(" ", string.Empty).Replace("\"",string.Empty);

            CreditCardChecker CCChecker = new CreditCardChecker();
            // Validate code acc to Lunh

            string cardVendorCheck = CCChecker.GetCreditCardVendor(goodInput);
            Console.WriteLine(cardVendorCheck);

            Console.WriteLine("Next valid credit card number is: " + CCChecker.GenerateNextCreditCardNumber(goodInput));
            Console.ReadLine();
        }

    }
}
