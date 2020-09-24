using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BankTransfers.Data.Models;
using BankTransfers.Data.Models.Dto;
using BankTransfers.Data.Repositories;
using BankTransfers.Service;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;

namespace BankTransfers.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IBankRepository _bankRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionService _transactionService;

        public AccountController(IAccountRepository accountRepository, IBankRepository bankRepository, ITransactionService transactionService)
        {
            _accountRepository = accountRepository;
            _bankRepository = bankRepository;
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Account_Read([DataSourceRequest] DataSourceRequest request)
        {
            var accounts = _accountRepository.GetAccountGridList();
            return Json((accounts.ToDataSourceResult(request)));
        }

        public IActionResult ToolbarTemplate_Banks()
        {
            var banks = _bankRepository.GetBankDropDownList();

            return Json(banks);
        }

        public IActionResult GetDropDown_Accounts()
        {
            var accounts = _accountRepository.GetAccountDropDownList();

            return Json(accounts);
        }

        public ActionResult GetTransferDialog(int fromAccountId)
        {
            var account = _accountRepository.GetAccountById(fromAccountId);
            var userName = User.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;

            var viewModel = new TransferDialogDto
            {
                FromAccountId = fromAccountId,
                FromAccountType = account.AccountType.Name,
                BankId = 1,
                UserName = userName
            };
            return PartialView("TransferDialog", viewModel);
        }

        [HttpPost]
        public ActionResult CreateTransferTransaction(TransferDialogDto transfer)
        {
            
            _transactionService.TransferBetweenAccounts(transfer);

            return RedirectToAction("Index");
        }
    }
}