using System;
using Kottans_CreditCardOperator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kottans_CreditCardOperator_Tests
{
    [TestClass]
    public class CreditCardCheckerTests
    {
        [TestMethod]
        public void IsCreditCardNumberValid_ValidNumber_Success()
        {
            CreditCardChecker ccchecker = new CreditCardChecker();
            bool result = ccchecker.IsCreditCardNumberValid("341134113411347");
            Assert.IsTrue(result);
        }
    }
}
