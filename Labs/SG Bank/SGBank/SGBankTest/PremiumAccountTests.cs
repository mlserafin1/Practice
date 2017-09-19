using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBankTest
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("33333", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("33333", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("33333", "Premium Account", 100, AccountType.Premium, 250, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("77777", "Premium Account", 100, AccountType.Basic, -50, false)]
        [TestCase("77777", "Premium Account", 30, AccountType.Premium, -550, false)]
        [TestCase("77777", "Premium Account", 100, AccountType.Premium, 100, false)]
        [TestCase("77777", "Premium Account", 150, AccountType.Premium, -50, true)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
