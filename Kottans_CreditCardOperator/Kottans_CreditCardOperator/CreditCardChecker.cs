using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kottans_CreditCardOperator
{
    public class CreditCardChecker
    {
        //Lenght -- American Express(15); Maestro(12-19); MasterCard(16); VISA(13,16,19); JCB(16)

        public string GetCreditCardVendor(string goodInput)
        {
            int[] maestroArray = { 50, 56, 57, 58, 59, 6 }; //50, 56-69
            int[] masterCardArray = { 2221, 2222, 2223, 2224, 2225, 2226, 2227, 2228, 2229, 23, 24, 25, 26, 270, 271, 2720, 51, 52, 53, 54, 55 }; //2221 - 2720; 51-55
            int[] jcbArray = { 3528, 3529, 353, 354, 355, 356, 357, 358 }; //3528-3589

            // Maestro 50, 56-69
            foreach (int item in maestroArray)
            {
                if (goodInput.StartsWith(item.ToString()))
                {
                    return "You've got a Maestro card";
                }
            }

            //MasterCard 2221 - 2720; 51-55
            foreach (int item in masterCardArray)
            {
                if (goodInput.StartsWith(item.ToString()))
                {
                    return "You've got a Master card";
                }
            }

            //JCB 3528-3589
            foreach (int item in jcbArray)
            {
                if (goodInput.StartsWith(item.ToString()))
                {
                    return "You've got a JCB card";
                }
            }

            //AmExpress 34, 37

            if (goodInput.StartsWith("34") || goodInput.StartsWith("37"))
                return "You've got an American Express card";

            //VISA 4
            else if (goodInput.StartsWith("4"))
                return "You've got a Visa card";


            else return "Sorry, we cannot decipher you credit card vendor.";

        }
        //AmEx == 15 digits <0000 000000 00000>
        public string GetCodeFormatted(string goodInput)
        {
            string inputFormatted = "";

            if (GetCreditCardVendor(goodInput) == "You've got an American Express card")
            {
                return inputFormatted = String.Format("{0:0000 000000 00000}", (Int64.Parse(goodInput)));
                //  return inputFormatted = String.Format("{0:0000 000000 00000}", input);
            }
            else
                return inputFormatted = String.Format("{0:0000 0000 0000 0000}", (Int64.Parse(goodInput)));
            // return inputFormatted = String.Format("{0:0000 0000 0000 0000}", input);
        }
        //StandardCode == 16 digits <0000 0000 0000 0000> 
        //most of Maestro cards; all Master cards; most Visa cards; all JCB.
        //So for those we'll ignore all the cards lenght deviations and will consider only standard 16-digits codes.

        public bool IsCreditCardNumberValid(string goodInput)
        {
            double doubled;
            double sumTotal = 0;

            char[] chars = goodInput.ToCharArray();
            List<double> digits = new List<double>();
            char[] charReverted = chars.Reverse().ToArray();
             
            foreach (char item in charReverted)
            {
                double d = char.GetNumericValue(item);
                digits.Add(d);
            }
            for (int i = 0; i < digits.Count; i++)
            {
                // 1010 1010 1010 1010
                // 1 - must be doubled 
                // 0 - left unchanged
                //for 0
                if ((i % 2) == 0)
                {
                    sumTotal = sumTotal + digits[i];
                }
                //for 1
                else
                {
                    if ((digits[i] * 2) > 9)
                    {
                        doubled = ((digits[i] * 2) - 9);
                        sumTotal = sumTotal + doubled;
                    }
                    else
                    {
                        sumTotal = sumTotal + digits[i] * 2;
                    }
                }

            }
            if ((sumTotal % 10) == 0)
            {
                return true;
            }
            else return false;
        }

        public string GetValidationResult(string goodInput)
        {
            if (IsCreditCardNumberValid(goodInput) == true)
            {
                return "Congrats, dude! That's a valid card number!";
            }
            else
            {
                return "Sorry looks like you've got an invalid credit card number. Double check the value you've entered.";
            }
        }
        public string GenerateNextCreditCardNumber(string goodInput)
        {
            bool isValid = false;
            Int64 inputNumeric = Int64.Parse(goodInput);
            while (isValid == false)
            {
                inputNumeric++;
                if (GetValidationResult(inputNumeric.ToString()).Contains("Congrats"))
                {
                    isValid = true;
                }
            }
            return GetCodeFormatted(inputNumeric.ToString());

        }



    }
}

