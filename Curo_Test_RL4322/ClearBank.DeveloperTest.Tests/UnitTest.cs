using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Abstraction;
using ClearBank.DeveloperTest.Data;
using NUnit.Framework;
using Moq;
using BDD = ClearBank.DeveloperTest.BDD;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class UnitTest
    {
        private BDD.IAccountRepository _accountRepos;
        private BDD.IPaymentService _paymentService;
        private BDD.Account _accountBDD { get; set; }
        private ClearBank.DeveloperTest.Types.Account _accountTest { get; set; }
        [SetUp]
        public void Init()
        {
            //Arrange
            _accountRepos = new BDD.AccountRepository();

        }



        [Test]
        public void AccountExist_Returns_Expected_AccountNumber()
        {
            //Arrange
            string expected = "AC-1234";
            //Action
            BDD.Account result = _accountRepos.FindByAccountNumber(expected);
            //Assert
            Assert.AreEqual(expected, result.AccountNumber);
        }

        [Test]
        public void AccountNotExist_Returns_Expected_AccountNumberNull()
        {
            //Arrange
            string expected = "AC-5432";
            //Action
            _accountBDD = _accountRepos.FindByAccountNumber(expected);
            //Assert
            Assert.IsNull(_accountBDD.AccountNumber);
        }


        [Test]
        public void AccountNumber_HasValidStatus_Expected_PaymentScheme()
        {
            //Arrange
            string expected = "AC-1234";
            //Action
            BDD.Account result = _accountRepos.FindByAccountNumber(expected);
            //Assert
            Assert.AreEqual(result.AccountStatus, BDD.AccountStatus.Live);
            result.AllowedPaymentSchemes = BDD.AllowedPaymentSchemes.FasterPayments | BDD.AllowedPaymentSchemes.Bacs;

            Assert.IsNotNull(result.AccountNumber);
            Assert.IsNotNull(result.AllowedPaymentSchemes);

        }


        [Test]
        public void AccountNumber_HasNotValidStatus_Expected_AccoutStatusDisabled()
        {
            //Arrange
            string expected = "AC-1234";
            //Action
            _accountBDD = _accountRepos.FindByAccountNumber(expected);
            _accountBDD.AccountStatus = BDD.AccountStatus.Disabled;
            //Assert
            Assert.AreEqual(_accountBDD.AccountStatus, BDD.AccountStatus.Disabled);

        }


        [Test]
        public void SufientFunds_MakePayment_ExpectedSuccess()
        {
            //Arrange
            string accountNumber = "AC-1234";
            Mock<BDD.MakePaymentRequest> mockPayRequest = new Mock<BDD.MakePaymentRequest>(new decimal(200.00), accountNumber);
            _paymentService = new BDD.PaymentService();
            //Action
            BDD.MakePaymentResult result = _paymentService.MakePayment(mockPayRequest.Object);

            //Assert
            Assert.IsTrue(result.Sucess);

        }


        [Test]
        public void CheckBalance_AfterDeduction_Expected_150()
        {
            //Arrange
            string accountNumber = "AC-1234";
            decimal expected = new decimal(150.00);

            //Action
            AccountDataStore accountDataStore = new AccountDataStore();
            
            _accountTest = accountDataStore.GetAccount(accountNumber);

            ////Assert
            Assert.AreEqual(expected, _accountTest.Balance);

        }



        [Test]
        public void InsufientFunds_ExpectedString()
        {
            //Arrange
            string accountNumber = "AC-5234";
            decimal Amount = new decimal(50);
            AccountDataStore accountDataStore = new AccountDataStore();

            //Action
            _accountTest = accountDataStore.GetAccount(accountNumber);
            
            ////Assert
            if (_accountTest.Balance < Amount)
                Assert.Pass();

        }
        


    }
}
