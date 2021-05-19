using System;
using System.Collections.Generic;
using System.Linq;
using PaymentMock.DTOs;
using PaymentMock.DTOs.Request;

namespace PaymentMock.Services.impl
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryService repositoryService;

        private const string Visa = "VISA";
        private const string Master = "MASTER";
        private const string MessageTypePayment = "PAYMENT";
        private const string MessageTypeAdjustment = "ADJUSTMENT";
        private const decimal VisaCommissionRate = 0.01m;
        private const decimal MasterCommissionRate = 0.02m;
        

        public PaymentService(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public List<Account> GetAccounts()
        {
          return repositoryService.GetAccounts();
        }

        public void Pay(PaymentInput input)
        {
            if (!CheckMessageType(MessageTypePayment, input.MessageType))
            {
                throw new Exception("Type is not valid");
            };

            List<Account> accounts = this.repositoryService.GetAccounts();

            if (accounts.Find(item => item.AccountId == input.AccountId)== null)
            {
                throw new Exception("Account not found.");
            }
            
            this.repositoryService.AddPaymentInput(input);
            
            decimal commission = CalculateCommission(input.Origin, input.Amount);
            decimal currentAmount = repositoryService.GetAmount(input.AccountId);
            decimal newAmount = currentAmount - input.Amount - commission;
            
            repositoryService.UpdateAccount(input.AccountId, newAmount);
        }

        public void Adjust(PaymentInput input)
        {
            var data = this.repositoryService.GetPyPaymentInputs();

            List<PaymentInput> test =  data.Where(item => item.AccountId == 4755 && item.TransactionId == 1981).ToList();
            //return null;

            var b = 6;
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
