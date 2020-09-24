using System.Collections.Generic;
using BankTransfers.Data.Models;
using BankTransfers.Data.Models.Dto;

namespace BankTransfers.Data.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetAccountById(int fromAccountId);
        IEnumerable<AccountGridListDto> GetAccountGridList();
        IEnumerable<AccountDropDownListDto> GetAccountDropDownList();
    }
}