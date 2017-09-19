using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private string _filename;

        public List<Account> accountList = new List<Account>();

        public FileAccountRepository(string filename)
        {
            _filename = filename;
        }

        public AccountType GetEnum(string s)
        {
            switch (s)
            {
                case "F":
                    return AccountType.Free;
                case "B":
                    return AccountType.Basic;
                case "P":
                    return AccountType.Premium;
                default:
                    throw new Exception("Not a valid account type in input file.");
            }
        }

        public static string ConvertToLetter(AccountType type)
        {
            switch (type)
            {
                case AccountType.Free:
                    return "F";
                case AccountType.Basic:
                    return "B";
                case AccountType.Premium:
                    return "P";
                default:
                    throw new Exception("Not a valid account type.");
            }
        }

        public Account LoadAccount(string accountNumber)
        {
            
            Account selectedAccount = new Account();
            selectedAccount = null; //this will return a null if no match is found to trigger the error message in the account manager lookup account method
            using (StreamReader sr = new StreamReader(_filename))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Account account = new Account();
                    bool temp;
                    decimal tempHolder;
                    string[] fields = line.Split(',');

                    account.AccountNumber = fields[0];
                    account.Name = fields[1];
                    temp = decimal.TryParse(fields[2], out tempHolder);
                    if (temp)
                    {
                        account.Balance = tempHolder;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Input file is not in the correct format. Contact IT.");
                        break;
                    }
                    account.Type = GetEnum(fields[3]);

                    accountList.Add(account);
                }
            }
            
            foreach (var acc in accountList)
            {
                if (acc.AccountNumber == accountNumber)
                {
                    selectedAccount = acc;
                }
            }

            return selectedAccount;
        }

        public void SaveAccount(Account account)
        {
            using (StreamWriter sw = new StreamWriter(_filename, false))
            {
                sw.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (var acc in accountList)
                {
                    if (acc.AccountNumber != account.AccountNumber)
                    {
                        sw.WriteLine("{0},{1},{2},{3}", acc.AccountNumber, acc.Name, acc.Balance,
                            ConvertToLetter(acc.Type));
                    }
                    else
                    {
                        sw.WriteLine("{0},{1},{2},{3}", account.AccountNumber, account.Name, account.Balance,
                            ConvertToLetter(account.Type));
                    }
                }
            }
        }
    }
}
