using PaymentMock.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentMock
{
    public class PaymentService : IPaymentService
    {
        private  AppContext AppContext { get; }

       
        public PaymentService(AppContext appContext)
        {
            AppContext = appContext;
        }

        public List<Account> GetAccounts(PaymentInput input)
        {
            return AppContext.Accounts.ToList();
        }

        public Account Pay(PaymentInput input)
        {
            return null;
        }

        public Account Adjust(PaymentInput input)
        {
            return null;
        }
    }
}
