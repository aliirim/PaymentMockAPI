using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using PaymentMock.DTOs;
using PaymentMock.DTOs.Request;
using PaymentMock.Services;

namespace PaymentMock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        
        private readonly ILogger<PaymentsController> logger;
        private readonly IPaymentService paymentService;
        
        public PaymentsController(ILogger<PaymentsController> logger,IPaymentService paymentService)
        {
            this.logger = logger;
            this.paymentService = paymentService;
        }

        /*[HttpGet]
        public IEnumerable<Account> Get([FromQuery]PaymentInput input)
        {
            var accounts= _paymentService.GetAccounts(input);
            return accounts;
        }*/

        [HttpPost("PAYMENT")]
        public IEnumerable<Account> Pay(PaymentInput input)
        {
            paymentService.Pay(input);
            return paymentService.GetAccounts();
        }

        [HttpPost("ADJUSTMENT")]
        public IEnumerable<Account> Adjust(PaymentInput input)
        {
            paymentService.Adjust(input);
            return paymentService.GetAccounts();
        }
    }
}
