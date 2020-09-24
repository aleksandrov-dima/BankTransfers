using System;
using System.Threading.Tasks;
using BankTransfers.Data.Models;

namespace BankTransfers.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public TransactionRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void AddTransaction(Transaction transaction, Account senderAccount, Account recipientAccount)
        {
            using (var efTransactionran = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {
                    _applicationDbContext.Add(transaction);

                    _applicationDbContext.Update(senderAccount);
                    _applicationDbContext.Update(recipientAccount);

                    _applicationDbContext.SaveChanges();

                    efTransactionran.Commit();
                }
                catch(Exception)
                {
                    throw new Exception("Не удалось выполнить перевод");
                }
            }
        }
    }
}