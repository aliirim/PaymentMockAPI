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
            CheckInputMessage(input, MessageTypePayment);
            
            repositoryService.AddPaymentInput(input);
            
            decimal commission = CalculateCommission(input.Origin, input.Amount);
            decimal currentAmount = repositoryService.GetAmount(input.AccountId);
            decimal newAmount = currentAmount - input.Amount - commission;
            
            repositoryService.UpdateAccount(input.AccountId, newAmount);
        }

        public void Adjust(PaymentInput input)
        {
            CheckInputMessage(input, MessageTypeAdjustment);

            List<PaymentInput> paymentInputs =
                repositoryService.GetPaymentInputsByAccountIdAndTransactionId(input.AccountId, input.TransactionId);
            
            if (paymentInputs.Count == 0)
            {
                throw new Exception("Transaction not found");
            }

            decimal oldAmount = paymentInputs[0].Amount;
            decimal correctedAmount = input.Amount + oldAmount - input.Amount;
            
            repositoryService.UpdateAccount(input.AccountId, correctedAmount);
        }

        private void CheckInputMessage(PaymentInput input, string messageType)
        {
            if (!CheckMessageType(messageType, input.MessageType))
            {
                throw new Exception("Message Type is not valid");
            }

            List<Account> accounts = repositoryService.GetAccounts();
            
            if (accounts.Find(item => item.AccountId == input.AccountId)== null)
            {
                throw new Exception("Account not found");
            }
            
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
