using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearBank.DeveloperTest.BDD
{
    public class PaymentService : IPaymentService
    {
        //Service Must Be Declouped
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            MakePaymentResult  _makePaymentResult = new MakePaymentResult();
            
            _makePaymentResult.Sucess = true;

            return _makePaymentResult;
        }
    }
}
