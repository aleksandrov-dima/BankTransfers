using System.Collections.Generic;

namespace BankTransfers.Data.Models
{
    /// <summary>
    /// Тип счета
    /// </summary>
    public class AccountType
    {
        public int Id { get; set; }
        
        public string Code { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<Account> Accounts { get; set; }
        
        public AccountType()
        {
            Accounts = new List<Account>();
        }   
    }
}