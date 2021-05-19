using System.Collections.Generic;
using System.Linq;
using PaymentMock.DTOs;

namespace PaymentMock.Services.impl
{
    public class RepositoryService
    {
        private  AppContext AppContext { get; }
        
        public RepositoryService(AppContext appContext)
        {
            AppContext = appContext;
        }
        
        public List<Account> GetAccounts()
        {
            return AppContext.Accounts.ToList();
        }
        
        public decimal GetAmount(int accountId)
        {
            Account account = AppContext.Accounts.Find(accountId);
            return account.Balance;
        }
        
        public void UpdateAccount(int accountId, decimal newAmount)
        {
            Account account = AppContext.Accounts.Find(accountId);
            account.Balance = newAmount;
            
            AppContext.Accounts.Update(account);
        }
        
    }
}