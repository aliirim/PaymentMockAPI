using System.Collections.Generic;
using System.Linq;
using PaymentMock.DTOs;
using PaymentMock.DTOs.Request;

namespace PaymentMock.Services.impl
{
    public class RepositoryService : IRepositoryService
    {
        private static readonly List<PaymentInput> PaymentInputs = new List<PaymentInput>();
        
        private  InitDataContext InitDataContext { get; }
        
        public RepositoryService(InitDataContext initDataContext)
        {
            InitDataContext = initDataContext;
        }
        
        public List<Account> GetAccounts()
        {
            return InitDataContext.Accounts.ToList();
        }
        
        public decimal GetAmount(int accountId)
        {
            Account account = InitDataContext.Accounts.Find(accountId);
            return account.Balance;
        }
        
        public void UpdateAccount(int accountId, decimal newAmount)
        {
            Account account = InitDataContext.Accounts.Find(accountId);
            account.Balance = newAmount;
            
            InitDataContext.Accounts.Update(account);
            InitDataContext.SaveChanges();
        }

        public void AddPaymentInput(PaymentInput paymentInput)
        {
            RepositoryService.PaymentInputs.Add(paymentInput);
        }

        public List<PaymentInput> GetPaymentInputsByAccountIdAndTransactionId(int accountId, int transactionId)
        {
            var data = GetPaymentInputs();

            return data.Where(item => item.AccountId == accountId && item.TransactionId == transactionId).ToList();
        }

        private List<PaymentInput> GetPaymentInputs() => RepositoryService.PaymentInputs;
    }
}