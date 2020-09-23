namespace BankTransfers.Data.Models
{
    /// <summary>
    /// Коммисия между счетами
    /// </summary>
    public class TransferCommision
    {
        public int Id { get; set; }
        
        public decimal Rate { get; set; }
        
        public int? SenderAccountTypeId { get; set; }
        public AccountType SenderAccountType { get; set; }
        
        public int? RecipientAccountTypeId { get; set; }
        public AccountType RecipientAccountType { get; set; }
    }
}