namespace PaymentMock.Controllers
{
    public class PaymentInput
    {
       
        public string MessageType { get; set; }
        public int TransactinId { get; set; }
        public int AccountId { get; set; }
        public string Origin { get; set; }
        public decimal Amount { get; set; }
    }
}