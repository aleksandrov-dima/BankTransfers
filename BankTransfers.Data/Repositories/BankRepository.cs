using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankTransfers.Data.Models;
using BankTransfers.Data.Models.Dto;

namespace BankTransfers.Data.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BankRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<BankDropDownListDto> GetBankDropDownList()
        {
            var bankList = GetAll()
                .Select(c => new BankDropDownListDto
                {
                    BankId = c.Id,
                    Name = c.Name
                })
                .OrderBy(o => o.Name);

            return bankList;
        }
    }
}
