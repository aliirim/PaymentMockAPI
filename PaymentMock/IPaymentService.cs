using PaymentMock.Controllers;
using System.Collections.Generic;

namespace PaymentMock
{
    public interface IPaymentService
    {
       
        Account Adjust(PaymentInput input);
        Account Pay(PaymentInput input);
        List<Account> GetAccounts(PaymentInput input);
    }
}