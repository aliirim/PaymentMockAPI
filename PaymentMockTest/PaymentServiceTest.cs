using System;
using PaymentMock.DTOs.Request;
using PaymentMock.Services.impl;
using Xunit;

namespace PaymentMockTest
{
    public class PaymentServiceTest
    {
        [Fact(DisplayName = "Throws type is not valid when message type is not provided")]
        public void InvalidMessageType()
        {
            MockRepositoryService repositoryService = new MockRepositoryService();
            PaymentService paymentService = new PaymentService(repositoryService);
            
            var exception = Assert.Throws<Exception>(() => paymentService.Pay(new PaymentInput()
            {
                
            }));
            
            Assert.Equal("Message Type is not valid", exception.Message);

        }
        
        [Fact(DisplayName = "Throws type is not valid when account is not provided")]
        public void AccountNotFound()
        {
            MockRepositoryService repositoryService = new MockRepositoryService();
            PaymentService paymentService = new PaymentService(repositoryService);
            
            var exception = Assert.Throws<Exception>(() => paymentService.Pay(new PaymentInput()
            {
                AccountId = 1289,
                MessageType = "PAYMENT"
            }));
            
            Assert.Equal("Account not found", exception.Message);

        }

        [Fact(DisplayName = "Throws type is not valid when transaction is not provided")]
        public void TransactionNotFound()
        {
            MockRepositoryService repositoryService = new MockRepositoryService();
            PaymentService paymentService = new PaymentService(repositoryService);
            
            var exception = Assert.Throws<Exception>(() => paymentService.Adjust(new PaymentInput()
            {
                AccountId = 4755,
                MessageType = "ADJUSTMENT",
                TransactionId = 0
            }));
            
            Assert.Equal("Transaction not found", exception.Message);
        }
    }
}