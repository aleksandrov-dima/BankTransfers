using System.Collections.Generic;

namespace BankTransfers.Data.Models
{
    /// <summary>
    /// Банк
    /// </summary>
    public class Bank
    {
        public int Id { get; set; }
        
        public string BIC { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<Account> Accounts { get; set; }
        
        public Bank()
        {
            Accounts = new List<Account>();
        }  
    }
}