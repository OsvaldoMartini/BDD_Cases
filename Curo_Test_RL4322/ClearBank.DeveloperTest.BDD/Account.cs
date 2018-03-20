using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearBank.DeveloperTest.BDD
{
    public class Account
    {
        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public AccountStatus AccountStatus { get; set; }

        public AllowedPaymentSchemes AllowedPaymentSchemes { get; set; }
}
}
