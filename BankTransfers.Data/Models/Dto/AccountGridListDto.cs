namespace BankTransfers.Data.Models.Dto
{
    public class AccountGridListDto
    {
        public int AccountId { get; set; }
        public string AccountType { get; set; }
        public string BankName { get; set; }
        public decimal Deposit { get; set; }
        public int? BankId { get; set; }
    }
}