using System.Collections.Generic;
using PaymentMock.DTOs;
using PaymentMock.DTOs.Request;
using PaymentMock.Services;
using PaymentMock.Services.impl;

namespace PaymentMockTest
{
    public class MockRepositoryService : IRepositoryService
    {
        private static readonly List<PaymentInput> PaymentInputs = new List<PaymentInput>();
        
        private List<Account>  accounts = new List<Account>();
        
        public MockRepositoryService()
        {
            var data1 = new Account
            {
                AccountId = 4755,
                Balance = 1001.88m
            };

            accounts.Add(data1);

            var data2 = new Account
            {
                AccountId = 9834,
                Balance = 456.45m
            };

            accounts.Add(data2);

            var data3 = new Account
            {
                AccountId = 7735,
                Balance = 89.36m
            };
            
            accounts.Add(data2);
        }
        
        public List<Account> GetAccounts()
        {
            return this.accounts;
        }

        public decimal GetAmount(int accountId)
        {
            Account account = this.accounts.Find(item => item.AccountId == accountId);
            return account.Balance;
        }
        
        public void UpdateAccount(int accountId, decimal newAmount)
        {
            Account account = this.accounts.Find(item => item.AccountId == accountId);

            account.Balance = newAmount;
        }

        public void AddPaymentInput(PaymentInput paymentInput)
        {
            MockRepositoryService.PaymentInputs.Add(paymentInput);
        }

        public List<PaymentInput> GetPyPaymentInputs() => MockRepositoryService.PaymentInputs;
    }
}