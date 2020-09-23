using System.Threading.Tasks;
using BankTransfers.Data.Models;
using BankTransfers.Data.Repositories;

namespace BankTransfers.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Task<Transaction> TransferBetweenAccounts(Account fromAccount, Account toAccount, decimal amaunt, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}