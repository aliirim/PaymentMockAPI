using System.Collections.Generic;
using System.Linq;
using PaymentMock.DTOs;

namespace PaymentMock.Services.impl
{
    public class RepositoryService
    {
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
        }
        
    }
}