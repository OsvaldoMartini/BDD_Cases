using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearBank.DeveloperTest.BDD
{
    public class MakePaymentRequest
    {
        public decimal Amount { get; set; }

        public string DebtorAccountNumber { get; set; }

        public MakePaymentRequest(decimal amount, string debtorAccountNumber)
        {
            Amount = amount;
            DebtorAccountNumber = debtorAccountNumber;
        }
    }
}
