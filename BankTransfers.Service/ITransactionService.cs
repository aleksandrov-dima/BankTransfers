using System;
using System.Threading.Tasks;
using BankTransfers.Data.Models;
using BankTransfers.Data.Models.Dto;

namespace BankTransfers.Service
{
    public interface ITransactionService
    {
        void TransferBetweenAccounts(TransferDialogDto transfer);
    }
}