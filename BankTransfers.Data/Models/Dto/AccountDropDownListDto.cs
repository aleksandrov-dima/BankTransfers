namespace BankTransfers.Data.Models.Dto
{
    public class AccountDropDownListDto
    {
        public int AccountId { get; set; }
        public string DisplayName { get; set; }
        public int? BankId { get; set; }
    }
}