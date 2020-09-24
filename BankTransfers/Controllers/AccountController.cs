using System.Linq;
using BankTransfers.Data.Models.Dto;
using BankTransfers.Data.Repositories;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;

namespace BankTransfers.Controllers
{
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
    }
}