using System.Collections.Generic;
using System.Security.Claims;

namespace BankTransfers.Data.Models.Dto
{
    public class TransferDialogDto
    {
        public int FromAccountId { get; set; }
        public string FromAccountType { get; set; }
        public decimal Amount { get; set; }
        public int? BankId { get; set; }

        public int? ToAccountId { get; set; }
        public string UserName { get; set; }
    }
}