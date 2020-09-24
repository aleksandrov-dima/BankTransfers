using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BankTransfers.Data.Models;
using BankTransfers.Data.Models.Dto;
using BankTransfers.Data.Repositories;

namespace BankTransfers.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// Создание транзакции на перевод между счетами
        /// </summary>
        /// <param name="transfer"></param>
        /// <returns></returns>
        public void TransferBetweenAccounts(TransferDialogDto transfer)
        {
            if (transfer == null)
            {
                throw new ArgumentNullException(nameof(transfer));
            }

            //отправитель
            var senderAccount = _accountRepository.GetAccountById(transfer.FromAccountId);

            if(transfer.ToAccountId == null)
                throw new InvalidOperationException("Не был указан счет получателя");

            //получатель
            var recipientAccount = _accountRepository.GetAccountById((int)transfer.ToAccountId);

            if (recipientAccount == null)
                throw new InvalidOperationException($"Не найден счет получателя {nameof(transfer.ToAccountId)}");

            decimal transferCommision;

            //вычисляем коммисию перевода
            if (senderAccount.AccountTypeId != null && recipientAccount.AccountTypeId != null)
            {
                transferCommision = GetTransferCommision(transfer.Amount,
                                                                    (int) senderAccount.AccountTypeId,
                                                                    (int) recipientAccount.AccountTypeId);
            }
            else
            {
                throw new InvalidOperationException("Не указан тип счета");
            }

            decimal bankCommision;
            //вычисляем коммисию банка
            if (senderAccount.BankId != null && recipientAccount.BankId != null)
            {
                bankCommision = GetBankCommision(transfer.Amount, 
                                                            (int)senderAccount.BankId,
                                                            (int)recipientAccount.BankId);
            }
            else
            {
                throw new InvalidOperationException("Не указан банк");
            }

            //проверяем баланс отправителя
            decimal senderNewDeposit = senderAccount.Deposit - (transfer.Amount + transferCommision + bankCommision);
            if(senderNewDeposit < 0)
                throw new InvalidOperationException($"На счете отправителя {transfer.FromAccountId} не достаточно средств");

            //создание транзакции перевода
            Transaction newtransaction = new Transaction()
            {
                Amount = transfer.Amount,
                TransferCommission = transferCommision,
                BankCommission = bankCommision,
                RecipientAccountId = recipientAccount.Id,
                SenderAccountId = senderAccount.Id,
                Date = DateTime.Now
            };

            //фиксируем изменения 
            senderAccount.Deposit = senderNewDeposit;
            recipientAccount.Deposit = recipientAccount.Deposit + transfer.Amount;
            
            _transactionRepository.AddTransaction(newtransaction, senderAccount, recipientAccount);
        }

        /// <summary>
        /// Вычисление коммисии банка
        /// </summary>
        /// <param name="senderAccountBankId"></param>
        /// <param name="recipientAccountBankId"></param>
        /// <returns></returns>
        private decimal GetBankCommision(decimal amount, int senderAccountBankId, int recipientAccountBankId)
        {
            //TODO: GetBankCommision
            return 0;
        }

        /// <summary>
        /// Вычисление коммисии перевода
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="senderAccountTypeId"></param>
        /// <param name="recipientAccountTypeId"></param>
        /// <returns></returns>
        private decimal GetTransferCommision(decimal amount, int senderAccountTypeId, int recipientAccountTypeId)
        {
            //TODO: GetTransferCommision
            return 0;
        }
    }
}