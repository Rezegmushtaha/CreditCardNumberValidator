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
            string cardVendorCheck = CCChecker.GetCreditCardVendor(goodInput);
            Console.WriteLine(cardVendorCheck);

            Console.WriteLine(CCChecker.GetValidationResult(goodInput));

            //Console.WriteLine("Do you want to have your credit card number formatted? -- Y/N");
            //string fAnswer = Console.ReadLine();
            //string formattedAnswer = fAnswer.ToLower();
            //if (formattedAnswer.Equals("y"))
            //{
            //    Console.WriteLine(CCChecker.GetCodeFormatted(goodInput) + "\nLet's proceed then.\n \rDo you want to validate your credit card number acc to Luhn formula? -- Y/N");
            //    string valAnswer = Console.ReadLine();
            //    string validationAnswer = valAnswer.ToLower();
            //    if (validationAnswer.Equals("y"))
            //    {
            //        Console.WriteLine(CCChecker.GetValidationResult(goodInput));
            //        //Console.ReadKey();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Ok, gotta! No formatting required. Let's proceed then.\n \rDo you want to validate your credit card number acc to Luhn formula? -- Y/N");
            //    string vAnswer = Console.ReadLine();
            //    string validateAnswer = vAnswer.ToLower();
            //    if (validateAnswer.Equals("y"))
            //    {
            //        Console.WriteLine(CCChecker.GetValidationResult(goodInput));
            //    }
            //}
            Console.WriteLine("Next valid credit card number is: " + CCChecker.GenerateNextCreditCardNumber(goodInput));
            Console.ReadLine();
        }

    }
}
