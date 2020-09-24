using System.Collections.Generic;
using System.Linq;
using BankTransfers.Data.Models;
using BankTransfers.Data.Models.Dto;

namespace BankTransfers.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public AccountRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Account GetAccount()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AccountGridListDto> GetAccountGridList()
        {
            var accountsList = GetAll().Select(s => new AccountGridListDto
            {
                AccountId = s.Id,
                AccountType = s.AccountType.Name,
                BankId = s.BankId,
                BankName = s.Bank.Name,
                Deposit = s.Deposit
            }).OrderBy(o=>o.BankId);

            return accountsList;
        }
    }
}