using System;
using BankTransfers.Data.Models.Security;

namespace BankTransfers.Data.Models
{
    /// <summary>
    /// Транзакция
    /// </summary>
    public class Transaction
    {
        public int Id { get; set; }
        
        public decimal Amount { get; set; }
        
        public decimal TransferCommission { get; set; }
        
        public decimal BankCommission { get; set; }
        
        public DateTime Date { get; set; }
        
        public int? UserId { get; set; }
        public User User { get; set; }
        
        public int? SenderAccountId { get; set; }
        public Account SenderAccount { get; set; }
        
        public int? RecipientAccountId { get; set; }
        public Account RecipientAccount { get; set; }
    }
}