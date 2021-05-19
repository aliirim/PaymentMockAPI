using Microsoft.EntityFrameworkCore;
using PaymentMock.DTOs;

namespace PaymentMock
{
    public class InitDataContext: DbContext
    {
       
        public InitDataContext(DbContextOptions<InitDataContext> options)
                : base(options)
        { 
            AddTestData(this);
        }

        public DbSet<Account> Accounts { get; set; }

        private static void AddTestData(InitDataContext context)
        {
            var data1 = new Account
            {
                AccountId = 4755,
                Balance = 1001.88m
            };

            context.Accounts.Add(data1);

            var data2 = new Account
            {
                AccountId = 9834,
                Balance = 456.45m
            };

            context.Accounts.Add(data2);

            var data3 = new Account
            {
                AccountId = 7735,
                Balance = 89.36m
            };

            context.Accounts.Add(data3);

            context.SaveChanges();
        }
    }

    /*public class Account
    {
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
    }*/
}
