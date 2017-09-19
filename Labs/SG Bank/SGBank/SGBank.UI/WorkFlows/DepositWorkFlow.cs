using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models.Responses;

namespace SGBank.UI.WorkFlows
{
    public class DepositWorkFlow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.WriteLine("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            bool decimalSuccess;
            decimal amount;
            do
            {
                Console.WriteLine("Enter a deposit amount: ");
                string lineInput = Console.ReadLine();

                decimalSuccess = decimal.TryParse(lineInput, out amount);
                if(decimalSuccess != true)
                {
                    Console.WriteLine("Deposit amounts must be a number.");
                }
            } while (decimalSuccess != true);

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Deposit completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance:C}");
                Console.WriteLine($"Amount deposited: {response.Amount:C}");
                Console.WriteLine($"New balance: {response.Account.Balance:C}");
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
