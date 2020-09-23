using System;
using System.Threading.Tasks;
using BankTransfers.Data.Models;

namespace BankTransfers.Service
{
    public interface ITransactionService
    {
        Task<Transaction> TransferBetweenAccounts(Account fromAccount, Account toAccount, decimal amaunt, int userId);
    }
}