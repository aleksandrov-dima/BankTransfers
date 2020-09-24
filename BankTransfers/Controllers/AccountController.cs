using System.Collections.Generic;
using System.Linq;
using BankTransfers.Data.Models;
using BankTransfers.Data.Models.Dto;
using BankTransfers.Data.Repositories;
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

        public AccountController(IAccountRepository accountRepository, IBankRepository bankRepository)
        {
            _accountRepository = accountRepository;
            _bankRepository = bankRepository;
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

        public ActionResult GetTransferDialog(int fromAccountId, string fromAccountType)
        {
            var account = _accountRepository.GetAccountById(fromAccountId);

            var viewModel = new TransferDialogDto
            {
                FromAccountId = fromAccountId,
                FromAccountType = account.AccountType.Name,
                BankId = 1
            };
            return PartialView("TransferDialog", viewModel);
        }

        [HttpPost]
        public ActionResult CreateTransferTransaction(TransferDialogDto transfer)
        {
            return Json(Ok());
        }
    }

    public class TransferDialogDto
    {
        public int FromAccountId { get; set; }
        public string FromAccountType { get; set; }
        public decimal Amount { get; set; }
        public int? BankId { get; set; }

        public int? ToAccountId { get; set; }
    }
}