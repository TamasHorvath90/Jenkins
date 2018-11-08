using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        private string _customerName;
        private double _balance;
        private bool _accountIsEnabled = true;

        public const string AccountIsDisabledMessage = ("Account is Disabled! Cannot execute this operation!");
        public const string AmountIsMoreThanBalanceMessage = ("The given amount is more than your Balance! Cannot execute this operation!");
        public const string AmountIsLessThanZeroMessage = ("The given amount is less than Zero! Cannot execute this operation!");

        public BankAccount(string customerName, double balance)
        {
            _customerName = customerName;
            _balance = balance;
        }

        public string CustomerName
        {
            get { return _customerName; }
        }

        public double Balance
        {
            get { return _balance; }
        }

        public bool AccountIsEnabled
        {
            get { return _accountIsEnabled; }
        }

        public void Debit(double amount)
        {
            if (!_accountIsEnabled)
            {
                throw new InvalidOperationException(AccountIsDisabledMessage);
            }

            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException(AmountIsMoreThanBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(AmountIsLessThanZeroMessage);
            }

            _balance -= amount;
        }

        public void Credit(double amount)
        {
            if (!_accountIsEnabled)
            {
                throw new Exception(AccountIsDisabledMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(AmountIsLessThanZeroMessage);
            }

            _balance += amount;
        }

        public void DisableAccount()
        {
            _accountIsEnabled = false;
        }

        public void EnableAccount()
        {
            _accountIsEnabled = true;
        }

        public static void Main()
        {
            BankAccount account = new BankAccount("Tamas Horvath", 200);

            account.Credit(20);
            account.Debit(40);
            Console.WriteLine("Current balance: {0}", account.Balance);
        }
    }
}
