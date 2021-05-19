using System;
using System.Collections.Generic;
using PaymentMock.DTOs;
using PaymentMock.DTOs.Request;

namespace PaymentMock.Services.impl
{
    public class PaymentService : IPaymentService
    {
        private readonly RepositoryService _repositoryService;

        private const string Visa = "VISA";
        private const string Master = "MASTER";
        private const string MessageTypePayment = "PAYMENT";
        private const string MessageTypeAdjustment = "ADJUSTMENT";
        private const decimal VisaCommissionRate = 0.01m;
        private const decimal MasterCommissionRate = 0.02m;
        

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
            if (!CheckMessageType(MessageTypePayment, input.MessageType)) return;
            
            decimal commission = CalculateCommission(input.Origin, input.Amount);
            decimal currentAmount = _repositoryService.GetAmount(input.AccountId);
            decimal newAmount = currentAmount - input.Amount - commission;
            
            _repositoryService.UpdateAccount(input.AccountId, newAmount);
        }

        public Account Adjust(PaymentInput input)
        {
            return null;
        }

        private decimal CalculateCommission(string origin, decimal amount )
        {
            if (Visa.Equals(origin))
            {
                return amount * VisaCommissionRate;
            }
            
            return amount * MasterCommissionRate;
        }

        private Boolean CheckMessageType(string messageType, string expectedMessageType)
        {
            return messageType.Equals(expectedMessageType);
        }
    }
}
