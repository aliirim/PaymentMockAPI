using Microsoft.EntityFrameworkCore;
using PaymentMock.DTOs.Request;

namespace PaymentMock
{
    public class MessageDataContext: DbContext
    {
        public MessageDataContext(DbContextOptions<InitDataContext> options)
            : base(options)
        { 
            
        }

        public DbSet<PaymentInput> Accounts { get; set; }
        
    }
}