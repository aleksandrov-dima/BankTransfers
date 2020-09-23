using BankTransfers.Data.Models;

namespace BankTransfers.Data.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetAccount();
    }
}