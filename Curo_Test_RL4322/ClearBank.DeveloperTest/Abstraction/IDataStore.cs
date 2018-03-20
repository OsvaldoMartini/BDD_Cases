using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Abstraction
{
    public interface IDataStore<T>
    {
        Account GetAccount(string accountNumber);
        void UpdateAccount(T account);
        
    }
}
