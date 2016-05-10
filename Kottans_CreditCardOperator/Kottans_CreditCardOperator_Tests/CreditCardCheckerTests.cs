using System;
using Kottans_CreditCardOperator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kottans_CreditCardOperator_Tests
{
    [TestClass]
    public class CreditCardCheckerTests
    {
        [TestMethod]
        public void IsCreditCardNumberValid_ValidVisaNumber_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            bool result = ccchecker.IsCreditCardNumberValid("3411 3411 3411 347");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsCreditCardNumberValid_ValidNumber_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            bool result = ccchecker.IsCreditCardNumberValid("3434 3434 3434 343");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsCreditCardNumberValid_ValidJcbNumber_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            bool result = ccchecker.IsCreditCardNumberValid("3530 1113 3330 0000");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsCreditCardNumberValid_ValidJcbNumber2_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            bool result = ccchecker.IsCreditCardNumberValid("3566 0020 2036 0505");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsCreditCardNumberValid_ValidAmExpNumber_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            bool result = ccchecker.IsCreditCardNumberValid("4111 1111 1111 1111");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsCreditCardNumberValid_ValidAmExprNumber2_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            bool result = ccchecker.IsCreditCardNumberValid("4222 2222 2222 2");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsCreditCardNumberValid_ValidNumber2_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            bool result = ccchecker.IsCreditCardNumberValid("5105 1051 0510 5100");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetCreditCardVendor_AmExpress_15_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            string result = ccchecker.GetCreditCardVendor("3411 3411 3411 347");
            Assert.IsTrue(result=="American Express");
        }

        [TestMethod]
        public void GetCreditCardVendor_JCB_16_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            string result = ccchecker.GetCreditCardVendor("3566 0020 2036 0505");
            Assert.IsTrue(result == "JCB");
        }

        [TestMethod]
        public void GetCreditCardVendor_MasterCard_16_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            string result = ccchecker.GetCreditCardVendor("5105 1051 0510 5100");
            Assert.IsTrue(result == "MasterCard");
        }

        [TestMethod]
        public void GetCreditCardVendor_Visa_13_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            string result = ccchecker.GetCreditCardVendor("4222 2222 2222 2");
            Assert.IsTrue(result == "VISA");
        }
    }
}
