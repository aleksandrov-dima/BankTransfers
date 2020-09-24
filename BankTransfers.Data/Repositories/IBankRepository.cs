using System;
using System.Collections.Generic;
using System.Text;
using BankTransfers.Data.Models;
using BankTransfers.Data.Models.Dto;

namespace BankTransfers.Data.Repositories
{
    public interface IBankRepository : IRepository<Bank>
    {
        IEnumerable<BankDropDownListDto> GetBankDropDownList();
    }
}
