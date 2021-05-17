using Microsoft.EntityFrameworkCore;

namespace PaymentMock
{
    public class AppContext: DbContext
    {
       
            public AppContext(DbContextOptions<AppContext> options)
                : base(options)
            {
            AddTestData(this);
            }

            public DbSet<Account> Accounts { get; set; }

        private static void AddTestData(AppContext context)
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

    public class Account
    {
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
    }
}
