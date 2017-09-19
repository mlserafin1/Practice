﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.UI
{
    public class ConsoleIO
    {
        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Balance: {account.Balance:C}");
        }
    }
}
