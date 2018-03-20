using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearBank.DeveloperTest.BDD
{
    public interface IAccountRepository
    {
        Account FindByAccountNumber(string accountNumber);
    }
}
