using System.Collections.Generic;
using PaymentMock.DTOs;
using PaymentMock.DTOs.Request;

namespace PaymentMock.Services
{
    public interface IRepositoryService
    {
        List<Account> GetAccounts();
        decimal GetAmount(int accountId);
        void UpdateAccount(int accountId, decimal newAmount);
        void AddPaymentInput(PaymentInput paymentInput);
        List<PaymentInput> GetPyPaymentInputs();
    }
}