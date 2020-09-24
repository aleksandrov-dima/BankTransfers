using System.Threading.Tasks;
using BankTransfers.Data.Models;

namespace BankTransfers.Data.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        void AddTransaction(Transaction transaction, Account senderAccount, Account recipientAccount);
    }
}