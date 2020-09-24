using System.Collections.Generic;
using System.Linq;
using BankTransfers.Data.Models;
using BankTransfers.Data.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace BankTransfers.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public AccountRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Account GetAccountById(int accountId)
        {
            return _applicationDbContext.Accounts
                .Include(i=>i.AccountType)
                .First(a=>a.Id == accountId);
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

        public IEnumerable<AccountDropDownListDto> GetAccountDropDownList()
        {
            var accountsList = GetAll()
                .Include(i => i.AccountType)
                .Include(i => i.Bank)
                .Select(s => new AccountDropDownListDto
                {
                    AccountId = s.Id,
                    DisplayName = $"{s.AccountType.Name} ({s.Bank.Name}), №{s.Id}, остаток:{s.Deposit}",
                    BankId = s.BankId
                }).OrderBy(o => o.BankId);

            return accountsList;
        }
    }
}