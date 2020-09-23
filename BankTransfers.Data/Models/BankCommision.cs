namespace BankTransfers.Data.Models
{
    /// <summary>
    /// Комиссия банка
    /// </summary>
    public class BankCommision
    {
        public int Id { get; set; }
        
        public decimal Rate { get; set; }
        
        public int? BankTransferTypeId { get; set; }
        public BankTransferType BankTransferType { get; set; }
        
        public int? BankId { get; set; }
        public Bank Bank { get; set; }
    }

    /// <summary>
    /// Тип перевода между банками
    /// </summary>
    public class BankTransferType
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}