using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentMock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentService paymentService;
        
        public PaymentsController(ILogger<PaymentsController> logger,IPaymentService paymentService)
        {
            _logger = logger;
            this.paymentService = paymentService;
           
        }

        [HttpGet]
        public IEnumerable<Account> Get([FromQuery]PaymentInput input)
        {
            var accounts= paymentService.GetAccounts(input);
            return accounts;
        }

        [HttpPost("pay")]
        public IEnumerable<Account> Pay(PaymentInput input)
        {
            return paymentService.GetAccounts(input);
        }

        [HttpPost("adjust")]
        public IEnumerable<Account> Adjust(PaymentInput input)
        {
            return paymentService.GetAccounts(input);
        }
    }
}
