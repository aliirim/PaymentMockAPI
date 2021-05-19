using PaymentMock.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentMock.DTOs;
using PaymentMock.DTOs.Request;
using PaymentMock.Services;

namespace PaymentMock.Services.impl
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
