using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void DebitTesting()
        {
            //Arrange
            double beginningBalance = 100;
            double debitAmount = 20;
            double expectedBalance = 80;

            BankAccount account = new BankAccount("Tamas Horvath", beginningBalance);

            //Act
            account.Debit(debitAmount);

            //Assert
            double actualBalance = account.Balance;
            Assert.AreEqual(expectedBalance, actualBalance, "Error! Debit method doesn't work fine or something went wrong!");
            Console.WriteLine("Debit method works fine!");
        }

        [TestMethod]
        public void CreditTesting()
        {
            //Declare
            double beginningBalance = 100;
            double creditAmount = 20;
            double expectedBalance = 120;

            //Create a new Enabled account
            BankAccount account = new BankAccount("Tamas Horvath", beginningBalance);

            //Debit
            account.Credit(creditAmount);

            //Check the actual balance
            double actualBalance = account.Balance;
            Assert.AreEqual(expectedBalance, actualBalance, "Error! Credit method doesn't work fine or something went wrong!");
            Console.WriteLine("Credit method works fine!");
        }

        [TestMethod]
        public void EnableAndDisableAccountTesting()
        {
            double beginningBalance = 100;

            //Create new  account (Enabled as default)
            BankAccount account = new BankAccount("Tamas Horvath", beginningBalance);

            //Disable the account
            account.DisableAccount();

            //Check the account is Disabled
            Assert.AreEqual(false, account.AccountIsEnabled,
                "Error! Account should be Disabled! DisableAccount method doesn't work fine or something went wrong!");
            Console.WriteLine("DisableAccount method works fine!");

            //Enable the account
            account.EnableAccount();

            //Check the account is Enabled
            Assert.AreEqual(true, account.AccountIsEnabled,
                "Error! Account should be Enabled! EnableAccount method doesn't work fine or something went wrong!");
            Console.WriteLine("EnableAccount method works fine!");
        }
    }
}
