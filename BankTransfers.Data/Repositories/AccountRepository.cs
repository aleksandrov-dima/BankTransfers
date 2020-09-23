using BankTransfers.Data.Models;

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
    }
}