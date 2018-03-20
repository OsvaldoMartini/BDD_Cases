using ClearBank.DeveloperTest.Abstraction;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data
{
    public class AccountDataStore:IDataStore<Account>
    {
        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            Account account = new Account();
            if (accountNumber == "AC-1234")
                account.Balance = new decimal(150.00);
            else
                account.Balance = new decimal(10.00);
    
            return account;
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}
