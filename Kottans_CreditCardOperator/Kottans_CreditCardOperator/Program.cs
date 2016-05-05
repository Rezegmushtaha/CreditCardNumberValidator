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
            Int64 input = Int64.Parse(Console.ReadLine());
            CreditCardChecker CCChecker = new CreditCardChecker();
            string cardVendorCheck = CCChecker.GetCreditCardVendor(input);
            Console.WriteLine(cardVendorCheck);
            //Console.ReadKey();

            Console.WriteLine("Do you want to have your credit card number formatted? -- Y/N");
            string fAnswer = Console.ReadLine();
            string formattedAnswer = fAnswer.ToLower();
            if (formattedAnswer.Equals("y"))
            {
                Console.WriteLine(CCChecker.GetCodeFormatted(input) + "\nLet's proceed then.\n \rDo you want to validate your credit card number acc to Luhn formula? -- Y/N");
                string valAnswer = Console.ReadLine();
                string validationAnswer = valAnswer.ToLower();
                if (validationAnswer.Equals("y"))
                {
                    Console.WriteLine(CCChecker.GetValidationResult(input));
                    //Console.ReadKey();
                }
            }
            else
            Console.WriteLine("Ok, gotta! No formatting required. Let's proceed then.\n \rDo you want to validate your credit card number acc to Luhn formula? -- Y/N");
            string vAnswer = Console.ReadLine();
            string validateAnswer = vAnswer.ToLower();
            if (validateAnswer.Equals("y"))
            {
                Console.WriteLine(CCChecker.GetValidationResult(input));
                Console.ReadKey();
            }
            Console.WriteLine("Next valid credit card number is: " + CCChecker.GenerateNextCreditCardNumber(input));
            Console.ReadLine();
        }
       
    }
}
