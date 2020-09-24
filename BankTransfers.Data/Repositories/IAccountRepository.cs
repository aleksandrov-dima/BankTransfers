using System.Collections.Generic;
using BankTransfers.Data.Models;
using BankTransfers.Data.Models.Dto;

namespace BankTransfers.Data.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetAccount();

        IEnumerable<AccountGridListDto> GetAccountGridList();
    }
}