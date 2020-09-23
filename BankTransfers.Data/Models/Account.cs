using System.Collections.Generic;

namespace BankTransfers.Data.Models
{
    /// <summary>
    /// Счёт
    /// </summary>
    public class Account
    {
        public int Id { get; set; }
        
        public decimal Deposit { get; set; }

        public int? AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
        
        public int? BankId { get; set; }
        public Bank Bank { get; set; }
    }
}