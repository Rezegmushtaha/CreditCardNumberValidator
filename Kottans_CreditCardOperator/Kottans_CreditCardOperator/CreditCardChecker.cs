﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kottans_CreditCardOperator
{
    public class CreditCardChecker
    {
        //Lenght -- American Express(15); Maestro(12-19); MasterCard(16); VISA(13,16,19); JCB(16)

        public string GetCreditCardVendor(string input)
        {
            string goodInput = input.Trim().Replace(" ", string.Empty).Replace("\"", string.Empty);
            int inputLength = goodInput.Length;
            int[] maestroArray = { 50, 56, 57, 58, 59, 6 }; //50, 56-69
            int[] masterCardArray = { 2221, 2222, 2223, 2224, 2225, 2226, 2227, 2228, 2229, 23, 24, 25, 26, 270, 271, 2720, 51, 52, 53, 54, 55 }; //2221 - 2720; 51-55
            int[] jcbArray = { 3528, 3529, 353, 354, 355, 356, 357, 358 }; //3528-3589

            if ((IsCreditCardLunhValid(goodInput) == true))
            {

                // Maestro 50, 56-69
                foreach (int item in maestroArray)
                {
                    if ((goodInput.StartsWith(item.ToString()) && ((inputLength == 12) || (inputLength == 13) || (inputLength == 14) || (inputLength == 15) || (inputLength == 16) || (inputLength == 17) || (inputLength == 18) || (inputLength == 19))))
                    {
                        return "Maestro";
                    }
                }

                //MasterCard 2221 - 2720; 51-55
                foreach (int item in masterCardArray)
                {
                    if ((goodInput.StartsWith(item.ToString())) && (inputLength == 16))
                    {
                        return "MasterCard";
                    }
                }

                //JCB 3528-3589
                foreach (int item in jcbArray)
                {
                    if ((goodInput.StartsWith(item.ToString())) && (inputLength == 16))
                    {
                        return "JCB";
                    }
                }

                //AmExpress 34, 37

                if ((goodInput.StartsWith("34") || goodInput.StartsWith("37")) && (inputLength == 15))
                    return "American Express";

                //VISA 4
                else if ((goodInput.StartsWith("4")) && ((inputLength == 13) || (inputLength == 16) || (inputLength == 19)))
                    return "VISA";


                else return "Unknown";
            }
            else
            {
                return "Cannot decipher the vendor, as it's not a valid credit card number.";
            }
        }

        public bool IsCreditCardLunhValid(string input)
        {
            string goodInput = input.Trim().Replace(" ", string.Empty).Replace("\"", string.Empty);
            double doubled;
            double sumTotal = 0;

            char[] chars = goodInput.ToCharArray();
            char[] charReversed = chars.Reverse().ToArray();

            List<double> digits = new List<double>();

            foreach (char item in charReversed)
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
            if (((sumTotal % 10) == 0))
            {
                return true;
            }
            else return false;
        }

        public bool IsCreditCardNumberValid(string input)
        {
           
            if (((IsCreditCardLunhValid(input) == true)) && ((GetCreditCardVendor(input)) != "Unknown"))
            {
                return true;
            }
            else return false;
        }

        public string GenerateNextCreditCardNumber(string input)
        {
            string goodInput = input.Trim().Replace(" ", string.Empty).Replace("\"", string.Empty);
            string myVendor = GetCreditCardVendor(goodInput);

            {
                bool isValid = false;
                Int64 inputNumeric = Int64.Parse(goodInput);
                while (isValid == false)
                {
                    inputNumeric++;
                    if ((IsCreditCardNumberValid(inputNumeric.ToString()) == true))
                    {
                        isValid = true;
                    }
                }
                if (GetCreditCardVendor(inputNumeric.ToString()) == myVendor)
                {
                    return inputNumeric.ToString();
                }
                else return "Hey! It's a valid number, but wrong vendor";
            }
          

        }



    }
}

