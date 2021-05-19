using System;
using PaymentMock.DTOs.Request;
using PaymentMock.Services.impl;
using Xunit;

namespace PaymentMockTest
{
    public class PaymentServiceTest
    {
        [Fact(DisplayName = "Throws type is not valid when type is not provided")]
        public void InvalidType()
        {
            MockRepositoryService repositoryService = new MockRepositoryService();
            PaymentService paymentService = new PaymentService(repositoryService);
            
            var exception = Assert.Throws<Exception>(() => paymentService.Pay(new PaymentInput()
            {
                
            }));
            
            Assert.Equal("Type is not valid", exception.Message);

        }
        
        [Fact(DisplayName = "Throws type is not valid when type is not provided")]
        public void AccountNotFound()
        {
            MockRepositoryService repositoryService = new MockRepositoryService();
            PaymentService paymentService = new PaymentService(repositoryService);
            
            var exception = Assert.Throws<Exception>(() => paymentService.Pay(new PaymentInput()
            {
                AccountId = 1453,
                MessageType = "PAYMENT"
            }));
            
            Assert.Equal("Account not found.", exception.Message);

        }
    }
}