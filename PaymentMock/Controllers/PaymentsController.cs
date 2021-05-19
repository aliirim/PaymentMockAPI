using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentMock.DTOs;
using PaymentMock.DTOs.Request;
using PaymentMock.Services;

namespace PaymentMock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentService _paymentService;
        
        public PaymentsController(ILogger<PaymentsController> logger,IPaymentService paymentService)
        {
            _logger = logger;
            this._paymentService = paymentService;
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
            return _paymentService.GetAccounts(input);
        }

        [HttpPost("ADJUSTMENT")]
        public IEnumerable<Account> Adjust(PaymentInput input)
        {
            return _paymentService.GetAccounts(input);
        }
    }
}
