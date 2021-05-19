using System;
using System.Collections.Generic;
using PaymentMock.DTOs;
using PaymentMock.DTOs.Request;

namespace PaymentMock.Services.impl
{
    public class PaymentService : IPaymentService
    {
        private readonly RepositoryService _repositoryService;

        private const string VISA = "VISA";
        private const string MASTER = "MASTER";
        private const string Message_Type_PAYMENT = "PAYMENT";
        private const string Message_Type_ADJUSTMENT = "ADJUSTMENT";
        private const decimal VISA_Commission_Rate = 0.01m;
        private const decimal MASTER_Commission_Rate = 0.02m;
        

        public PaymentService(RepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public List<Account> GetAccounts()
        {
          return _repositoryService.GetAccounts();
        }

        public void Pay(PaymentInput input)
        {
            if (!CheckMessageType(Message_Type_PAYMENT, input.MessageType)) return;
            
            decimal commission = CalculateCommission(input.Origin, input.Amount);
            decimal currentAmount = _repositoryService.GetAmount(input.AccountId);
            decimal newAmount = currentAmount + input.Amount + commission;
            
            _repositoryService.UpdateAccount(input.AccountId, newAmount);
        }

        public Account Adjust(PaymentInput input)
        {
            return null;
        }

        private decimal CalculateCommission(string origin, decimal amount )
        {
            if (VISA.Equals(origin))
            {
                return amount * VISA_Commission_Rate;
            }
            
            return amount * MASTER_Commission_Rate;
        }

        private Boolean CheckMessageType(string messageType, string expectedMessageType)
        {
            return messageType.Equals(expectedMessageType);
        }
    }
}
