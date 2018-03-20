using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearBank.DeveloperTest.BDD
{
    public class AccountRepository : IAccountRepository
    {

        public Account FindByAccountNumber(string accountNumber)
        {
            var account = new Account();
            if (accountNumber == "AC-1234")
                account.AccountNumber = accountNumber;
            
            return account;
        }
    }
}
