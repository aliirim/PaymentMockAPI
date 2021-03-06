using System.Collections.Generic;
using PaymentMock.DTOs;
using PaymentMock.DTOs.Request;

namespace PaymentMock.Services
{
    public interface IPaymentService
    {
        void Adjust(PaymentInput input);
        void Pay(PaymentInput input);
        List<Account> GetAccounts();
    }
}