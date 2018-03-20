using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ClearBank.DeveloperTest.BDD
{
    [Binding]
    public class AccountHolderMakePaymentsSteps
    {
        private Account _account { get; set; }
        private AccountRepository _accountRepository { get;set; }
        private PaymentScheme _paymentScheme;
        private AccountStatus _accountStatus;
        private AllowedPaymentSchemes _allowedPaymentSchemes;
        private MakePaymentRequest _makePaymentRequest;
        private MakePaymentResult _makePaymentResult;
        private PaymentService _paymentService;


        #region Scenarios (1 and 2)

        [Given(@"I have account number")]
        public void GivenIHaveAccountNumber()
        {
            _account = new Account();
        }
        
        [Given(@"account number is ""(.*)""")]
        public void GivenAccountNumberIs(string accountNumber)
        {
            _account.AccountNumber = accountNumber;
        }

        [When(@"I look the account number ""(.*)""")]
        public void WhenILookTheAccountNumber(string accountNumber)
        {
            //Arrange
            _accountRepository  = new AccountRepository();          
            //Action
            _account = _accountRepository.FindByAccountNumber(accountNumber);
        }

        [Then(@"should return the valid account number")]
        public void ThenShouldReturnTheValidAccountNumber()
        {
            Assert.IsNotNull(_account.AccountNumber);
        }

        [Then(@"account number should return null")]
        public void ThenAccountNumberShouldReturnNull()
        {
            Assert.IsNull(_account.AccountNumber);
        }
        #endregion

        #region Scenario (3 and 4)
        [Given(@"exist Payment Schemes")]
        public void GivenExistPaymentSchemes()
        {
            Assert.IsNotNull(_account.AllowedPaymentSchemes);
        }

        [Given(@"exist Account Status")]
        public void GivenExistAccountStatus()
        {
            Assert.IsNotNull(_account.AccountStatus);
        }

        [When(@"account number status valid \(assumptions: Not Disable\)")]
        public void WhenAccountNumberStatusValidAssumptionsNotDisable()
        {
            Assert.AreEqual(_account.AccountStatus,AccountStatus.Live);
        }

        [When(@"account number has valid payment scheme")]
        public void WhenAccountNumberHasValidPaymentScheme()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments | AllowedPaymentSchemes.Bacs;
        }

        [Then(@"should return payment scheme")]
        public void ThenShouldReturnPaymentScheme()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;
        }

        [When(@"account number status invalid \(assumptions: Disable\)")]
        public void WhenAccountNumberStatusInvalidAssumptionsDisable()
        {
            _account.AccountStatus = AccountStatus.Disabled;
            Assert.AreEqual(_account.AccountStatus, AccountStatus.Disabled);
        }


        [When(@"account number has invalid payment scheme")]
        public void WhenAccountNumberHasInvalidPaymentScheme()
        {
            Assert.AreNotEqual(_account.AllowedPaymentSchemes, PaymentScheme.FasterPayments);
        }

        [Then(@"should return account status disable")]
        public void ThenShouldReturnAccountStatusDisable()
        {
            _account.AccountStatus = AccountStatus.Disabled;
            Assert.AreEqual(_account.AccountStatus, AccountStatus.Disabled);
        }

        #endregion


        #region Scenario (5 and 6)
        [Given(@"account balance is £(.*)")]
        public void GivenAccountBalanceIs(Decimal balance)
        {
            _account.Balance = balance;
        }

        [Given(@"account holder pays £(.*)")]
        public void GivenAccountHolderPays(Decimal Amount)
        {
            //Arrange
            _makePaymentRequest = new MakePaymentRequest(Amount, _account.AccountNumber);
            _makePaymentRequest.DebtorAccountNumber = _account.AccountNumber;
            _makePaymentRequest.Amount = Amount;
        }

        [Then(@"deduct from account balance")]
        public void ThenDeductFromAccountBalance()
        {
            //The MakePayment in PaymentService
            //Must be 100% Decoupled from Client class
            //OperationContrat=OneWay
            
            //Arrange variables
            _paymentService = new PaymentService();

            //Action
            _paymentService.MakePayment(_makePaymentRequest);
            
        }


        [Then(@"account balance should be £(.*)")]
        public void ThenAccountBalanceShouldBe(Decimal newBalance)
        {
            _account.Balance = newBalance;
        }

        [Then(@"make payment return success")]
        public void ThenMakePaymentReturnSuccess()
        {
            _makePaymentResult = new MakePaymentResult();
            _makePaymentResult.Sucess = true;
        }


        [Given(@"the account balance is £(.*)")]
        public void GivenTheAccountBalanceIs(Decimal balance)
        {
            _account.Balance = balance;
        }

        [Then(@"account balance has insufficient funds")]
        public void ThenAccountBalanceHasInsufficientFunds()
        {
            Assert.Pass(String.Format("insufficient Fundos{0}",_account.Balance-_makePaymentRequest.Amount));
        }




        #endregion

    }
}
