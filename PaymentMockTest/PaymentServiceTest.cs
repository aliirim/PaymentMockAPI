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

        [Fact(DisplayName = "When the payment has been calculated successfully")]
        public void SuccessfulPayment()
        {
            MockRepositoryService repositoryService = new MockRepositoryService();
            PaymentService paymentService = new PaymentService(repositoryService);

            paymentService.Pay(new PaymentInput()
            {
                AccountId = 4755,
                MessageType = "PAYMENT",
                TransactionId = 1,
                Origin = "VISA",
                Amount = 100
            });

            decimal expectedResult = 900.88m;
            decimal  amount = repositoryService.GetAmount(4755);
            
            Assert.Equal(expectedResult, amount);
        }
        
        [Fact(DisplayName = "When the adjustment has been calculated successfully")]
        public void SuccessfulAdjustment()
        {
            MockRepositoryService repositoryService = new MockRepositoryService();
            PaymentService paymentService = new PaymentService(repositoryService);

            paymentService.Pay(new PaymentInput()
            {
                AccountId = 4755,
                MessageType = "PAYMENT",
                TransactionId = 1,
                Origin = "VISA",
                Amount = 100
            });
            
            paymentService.Adjust(new PaymentInput()
            {
                AccountId = 4755,
                MessageType = "ADJUSTMENT",
                TransactionId = 1,
                Origin = "VISA",
                Amount = 50
            });

            decimal expectedResult = 950.88m;
            decimal  amount = repositoryService.GetAmount(4755);
            
            Assert.Equal(expectedResult, amount);
        }
    }
}